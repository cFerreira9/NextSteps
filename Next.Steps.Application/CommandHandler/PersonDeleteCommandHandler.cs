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
    public class PersonDeleteCommandHandler : RequestHandler<PersonDeleteCommand, bool>
    {
        private readonly IPersonService _service;

        public PersonDeleteCommandHandler(IPersonService service)
        {
            _service = service;
        }

        protected override bool Handle(PersonDeleteCommand request)
        {
            return _service.Delete(request.Id);
        }
    }
}