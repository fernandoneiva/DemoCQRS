using BuildingBlocks.EventBus.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        void AddSubscription<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;

        void AddSubscription<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>;

        void AddSubscription(Type handlerType, string eventName, Type eventType = null);

        bool HasSubscriptionsForEvent(string eventName);

        IEnumerable GetHandlersForEvent<TEvent>()
            where TEvent : IntegrationEvent;

        IEnumerable GetHandlersForEvent(string eventName);
    }
}
