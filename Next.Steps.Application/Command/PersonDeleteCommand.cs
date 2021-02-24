using MediatR;
using Next.Steps.Application.Dto;

namespace Next.Steps.Application.Command
{
    public class PersonDeleteCommand : IRequest<bool>
    {
        public int Id;
    }
}