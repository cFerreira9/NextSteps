using MediatR;
using Next.Steps.Application.Query;
using System.Threading;
using System.Threading.Tasks;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetByIdQueryHandler : IRequestHandler<PersonGetByIdQuery, string>
    {
        public Task<string> Handle(PersonGetByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}