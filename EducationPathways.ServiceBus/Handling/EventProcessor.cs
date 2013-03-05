﻿using EducationPathways.Contracts;
using EducationPathways.ServiceBus.Serialization;

namespace EducationPathways.ServiceBus.Handling
{
    /// <summary>
    /// Processes incoming events from the bus and routes them to the appropriate 
    /// handlers.
    /// </summary>
    // TODO: now that we have just one handler per subscription, it doesn't make 
    // much sense to have this processor doing multi dispatch.
    public class EventProcessor : MessageProcessor, IEventHandlerRegistry
    {
        private readonly EventDispatcher eventDispatcher;

        public EventProcessor(IMessageReceiver receiver, ITextSerializer serializer)
            : base(receiver, serializer)
        {
            this.eventDispatcher = new EventDispatcher();
        }

        public void Register(IEventHandler eventHandler)
        {
            this.eventDispatcher.Register(eventHandler);
        }

        protected override void ProcessMessage(string traceIdentifier, object payload, string messageId, string correlationId)
        {
            var @event = payload as IEvent;
            if (@event != null)
            {
                this.eventDispatcher.DispatchMessage(@event, messageId, correlationId, traceIdentifier);
            }
        }
    }
}
