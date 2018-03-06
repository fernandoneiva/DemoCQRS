using DemoCQRS.Domain.Core.Aggregates;
using MediatR;

namespace DemoCQRS.Application.Core.CommandStack
{
    public class SalvarFaturaCommand : IRequest
    {
        Fatura fatura;

    }
}
