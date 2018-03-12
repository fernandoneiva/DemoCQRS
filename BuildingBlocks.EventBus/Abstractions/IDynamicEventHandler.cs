using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IDynamicEventHandler
    {
        Task Handle(dynamic @event);
    }
}
