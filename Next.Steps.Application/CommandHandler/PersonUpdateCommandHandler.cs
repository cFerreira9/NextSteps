using AutoMapper;
using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonUpdateCommandHandler : RequestHandler<PersonUpdateCommand, bool>
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonUpdateCommandHandler(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override bool Handle(PersonUpdateCommand request)
        {
            var result = _mapper.Map<PersonUpdateDto, Person>(request.Person);

            return _service.Update(result);
        }
    }
}