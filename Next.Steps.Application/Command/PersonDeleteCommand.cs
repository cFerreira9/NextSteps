using MediatR;
using Next.Steps.Application.Dto;

namespace Next.Steps.Application.Command
{
    public class PersonDeleteCommand : IRequest
    {
        public PersonReadDto Person { get; set; }
    }
}