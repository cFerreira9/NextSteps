using MediatR;

namespace Next.Steps.Application.Command
{
    public class PersonDeleteCommand : IRequest<bool>
    {
        public int Id;
    }
}