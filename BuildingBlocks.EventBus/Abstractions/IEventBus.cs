using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>;

        void Subscribe<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;

        void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IEventHandler<TEvent>;

        void Unsubscribe<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;
    }
}
