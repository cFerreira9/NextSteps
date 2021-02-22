using MediatR;
using Next.Steps.Application.Dto;

namespace Next.Steps.Application.Command
{
    public class PersonUpdateCommand : IRequest
    {
        public PersonDto Person { get; set; }
    }
}