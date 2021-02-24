using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonDeleteCommandHandler : RequestHandler<PersonDeleteCommand>
    {
        private IPersonService _service;

        public PersonDeleteCommandHandler(IPersonService service)
        {
            _service = service;
        }

        protected override void Handle(PersonDeleteCommand request)
        {
            

            _service.Delete();
        }
    }
}