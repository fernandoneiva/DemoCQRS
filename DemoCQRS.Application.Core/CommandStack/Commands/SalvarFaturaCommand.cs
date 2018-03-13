using BuildingBlocks.EventBus.Events;
using DemoCQRS.Domain.Core.Aggregates;
using MediatR;

namespace DemoCQRS.Application.Core.CommandStack
{
    public class SalvarFaturaCommand : IntegrationEvent, IRequest
    {
        Fatura fatura;

    }
}
