using Microsoft.ServiceBus.Messaging;
using System;

namespace EducationPathways.ServiceBus
{
    /// <summary>
    /// Abstracts the behavior of a receiving component that raises 
    /// an event for every received event.
    /// </summary>
    public interface IMessageReceiver
    {
        /// <summary>
        /// Starts the listener.
        /// </summary>
        /// <param name="messageHandler">Handler for incoming messages. The return value indicates how to release the message lock.</param>
        void Start(Func<BrokeredMessage, MessageReleaseAction> messageHandler);

        /// <summary>
        /// Stops the listener.
        /// </summary>
        void Stop();
    }
}
