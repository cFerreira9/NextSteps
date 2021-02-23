using MediatR;

namespace Next.Steps.Application.Query
{
    public class PersonGetByIdQuery : IRequest<string>
    {
        public int Id { get; set; }

    }
}