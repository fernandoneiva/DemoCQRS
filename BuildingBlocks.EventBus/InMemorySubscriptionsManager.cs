using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus
{
    public class InMemorySubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly IDictionary<string, IList<Subscription>> _handlers =
            new Dictionary<string, IList<Subscription>>();

        public bool IsEmpty => !_handlers.Keys.Any();

        public event EventHandler<string> OnEventRemoved;
        public event EventHandler<string> OnEventAdded;

        public void AddSubscription<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler
        {
            this.AddSubscription(
                typeof(TEventHandler),
                eventName
            );
        }

        public void AddSubscription<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            this.AddSubscription(
                typeof(TEventHandler),
                typeof(TEvent).Name,
                typeof(TEvent)
            );
        }

        public void AddSubscription(Type handlerType, string eventName, Type eventType = null)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<Subscription>());
                OnEventAdded?.Invoke(this, eventName);
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(
                Subscription.New(
                        handlerType, 
                        eventType
                    )
                );
        }

        public bool HasSubscriptionsForEvent(string eventName) =>
            _handlers.ContainsKey(eventName);

        public IEnumerable GetHandlersForEvent<TEvent>()
            where TEvent : IntegrationEvent
        {
            var key = typeof(TEvent).Name;
            return GetHandlersForEvent(key);
        }

        public IEnumerable GetHandlersForEvent(string eventName)
            => _handlers[eventName];

        public Type GetEventTypeByName(string eventName) => _handlers[eventName]
            ?.FirstOrDefault(handler => !handler.IsDynamic)
            ?.EventType;
    }
}
