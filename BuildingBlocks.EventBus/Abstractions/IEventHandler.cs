using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventHandler<TEvent>
        where TEvent : IntegrationEvent
    {
        Task Handle(TEvent @event);
    }
}
