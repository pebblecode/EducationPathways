using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.ServiceBus;
using Microsoft.Practices.TransientFaultHandling;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace EducationPathways.ServiceBus
{
    /// <summary>
    /// Implements an asynchronous sender of messages to a Windows Azure Service Bus topic.
    /// </summary>
    public class TopicSender : IMessageSender
    {
        private readonly TokenProvider tokenProvider;
        private readonly Uri serviceUri;
        private readonly ServiceBusSettings settings;
        private readonly string topic;
        private readonly RetryPolicy retryPolicy;
        private readonly TopicClient topicClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicSender"/> class, 
        /// automatically creating the given topic if it does not exist.
        /// </summary>
        public TopicSender(ServiceBusSettings settings, string topic)
            : this(settings, topic, new ExponentialBackoff(10, TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(1)))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicSender"/> class, 
        /// automatically creating the given topic if it does not exist.
        /// </summary>
        protected TopicSender(ServiceBusSettings settings, string topic, RetryStrategy retryStrategy)
        {
            this.settings = settings;
            this.topic = topic;

            this.tokenProvider = TokenProvider.CreateSharedSecretTokenProvider(settings.TokenIssuer, settings.TokenAccessKey);
            this.serviceUri = ServiceBusEnvironment.CreateServiceUri(settings.ServiceUriScheme, settings.ServiceNamespace, settings.ServicePath);

            // TODO: This could be injected.
            this.retryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(retryStrategy);
            this.retryPolicy.Retrying +=
                (s, e) =>
                {
                    var handler = this.Retrying;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }

                    Trace.TraceWarning("An error occurred in attempt number {1} to send a message: {0}", e.LastException.Message, e.CurrentRetryCount);
                };

            var factory = MessagingFactory.Create(this.serviceUri, this.tokenProvider);
            this.topicClient = factory.CreateTopicClient(this.topic);


            var namespaceManager = new NamespaceManager(this.serviceUri, this.tokenProvider);

            foreach (var topicSettings in settings.Topics)
            {
                if (!namespaceManager.TopicExists(topicSettings.Path))
                {
                    namespaceManager.CreateTopic(topicSettings.Path);
                }

                foreach (var subscriptionSetting in topicSettings.Subscriptions)
                {
                    if (!namespaceManager.SubscriptionExists(topicSettings.Path, subscriptionSetting.Name))
                    {
                        namespaceManager.CreateSubscription(topicSettings.Path, subscriptionSetting.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Notifies that the sender is retrying due to a transient fault.
        /// </summary>
        public event EventHandler Retrying;

        /// <summary>
        /// Asynchronously sends the specified message.
        /// </summary>
        public void SendAsync(Func<BrokeredMessage> messageFactory)
        {
            // TODO: SendAsync is not currently being used by the app or infrastructure.
            // Consider removing or have a callback notifying the result.
            // Always send async.
            this.SendAsync(messageFactory, () => { }, ex => { });
        }

        public void SendAsync(IEnumerable<Func<BrokeredMessage>> messageFactories)
        {
            // TODO: batch/transactional sending?
            foreach (var messageFactory in messageFactories)
            {
                this.SendAsync(messageFactory);
            }
        }

        public void SendAsync(Func<BrokeredMessage> messageFactory, Action successCallback, Action<Exception> exceptionCallback)
        {
            this.retryPolicy.ExecuteAction(
                ac => this.DoBeginSendMessage(messageFactory(), ac),
                this.DoEndSendMessage,
                successCallback,
                ex =>
                {
                    Trace.TraceError("An unrecoverable error occurred while trying to send a message:\r\n{0}", ex);
                    exceptionCallback(ex);
                });
        }

        public void Send(Func<BrokeredMessage> messageFactory)
        {
            var resetEvent = new ManualResetEvent(false);
            Exception exception = null;

            this.SendAsync(
                messageFactory,
                () => resetEvent.Set(),
                ex =>
                {
                    exception = ex;
                    resetEvent.Set();
                });

            resetEvent.WaitOne();
            if (exception != null)
            {
                throw exception;
            }
        }

        protected virtual void DoBeginSendMessage(BrokeredMessage message, AsyncCallback ac)
        {
            try
            {
                this.topicClient.BeginSend(message, ac, message);
            }
            catch
            {
                message.Dispose();
                throw;
            }
        }

        protected virtual void DoEndSendMessage(IAsyncResult ar)
        {
            try
            {
                this.topicClient.EndSend(ar);
            }
            finally
            {
                using (ar.AsyncState as IDisposable) { }
            }
        }
    }
}
