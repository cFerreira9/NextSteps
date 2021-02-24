using MediatR;

namespace Next.Steps.Application.Query
{
    public class PersonGetByIdQuery : IRequest
    {
        public int Id { get; set; }

    }
}