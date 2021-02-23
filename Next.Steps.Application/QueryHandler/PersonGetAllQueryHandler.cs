using MediatR;
using Next.Steps.Application.Query;
using System.Threading;
using System.Threading.Tasks;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetAllQueryHandler : IRequestHandler<PersonGetAllQuery, string>
    {
        public Task<string> Handle(PersonGetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}