using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoCQRS.Application.Core.CommandStack.Handlers
{
    public class FaturasCommandHandler : IRequestHandler<SalvarFaturaCommand>
    {
        public Task Handle(SalvarFaturaCommand message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
