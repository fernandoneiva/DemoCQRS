using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IEventBusSubscriptionsManager manager = 
            new InMemorySubscriptionsManager();

        public void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            throw new NotImplementedException();
        }
    }
}
