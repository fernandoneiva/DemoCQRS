using BuildingBlocks.EventBus.Abstractions;
using DemoCQRS.Application.Core.CommandStack.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCQRS.Application.Core.CommandStack.Handlers
{
    public class NovaFaturaSalvaEventHandler : IEventHandler<NovaFaturaSalvaEvent>
    {
        public Task Handle(NovaFaturaSalvaEvent @event)
        {
            Debug.WriteLine($"Foi salvo uma nova fatura no momento {@event.CreationDate.ToString()}");
            return Task.CompletedTask;
        }
    }
}
