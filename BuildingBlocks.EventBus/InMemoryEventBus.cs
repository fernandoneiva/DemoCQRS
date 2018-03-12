using Autofac;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IEventBusSubscriptionsManager _manager = 
            new InMemorySubscriptionsManager();

        private readonly ILifetimeScope _scope;

        public InMemoryEventBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async void Publish(IntegrationEvent @event)
        {
            var subscriptions = _manager.GetHandlersForEvent(@event.GetType().Name);
            foreach (var subcription in subscriptions)
            {
                var message = JsonConvert.SerializeObject(@event);
                await subcription.Handle(message, _scope);
            }
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            _manager.AddSubscription<TEvent, TEventHandler>();
        }

        public void Subscribe<TEventHandler>(string eventName) 
            where TEventHandler : IDynamicEventHandler
        {
            _manager.AddSubscription<TEventHandler>(eventName);
        }

        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            _manager.RemoveSubscription<TEvent, TEventHandler>();
        }

        public void Unsubscribe<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            _manager.RemoveSubscription<TEventHandler>(eventName);
        }
    }
}
