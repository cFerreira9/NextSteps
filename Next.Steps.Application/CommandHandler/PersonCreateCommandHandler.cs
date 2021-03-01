using AutoMapper;
using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonCreateCommandHandler : RequestHandler<PersonCreateCommand, bool>
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonCreateCommandHandler(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override bool Handle(PersonCreateCommand request)
        {
            var result = _mapper.Map<PersonWriteDto, Person>(request.Person);
            return _service.Create(result);
        }
    }
}