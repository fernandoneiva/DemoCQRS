using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using DemoCQRS.Application.Core.CommandStack.Events;
using MediatR;

namespace DemoCQRS.Application.Core.CommandStack.Handlers
{
    public class FaturasCommandHandler : IEventHandler<SalvarFaturaCommand>, IRequestHandler<SalvarFaturaCommand>
    {
        private readonly IEventBus eventBus;

        public FaturasCommandHandler(IEventBus _eventBus)
        {
            eventBus = _eventBus;
        }

        public Task Handle(SalvarFaturaCommand message, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Handled: SalvarFaturaCommand");
            return Task.CompletedTask;
        }

        public Task Handle(SalvarFaturaCommand @event)
        {
            Debug.WriteLine("Handled: SalvarFaturaCommand");
            eventBus.Publish(new NovaFaturaSalvaEvent());
            return Task.CompletedTask;
        }
    }
}
