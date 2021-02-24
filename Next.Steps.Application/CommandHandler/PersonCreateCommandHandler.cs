using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonCreateCommandHandler : RequestHandler<PersonCreateCommand>
    {
        private IPersonService _service;

        public PersonCreateCommandHandler(IPersonService service)
        {
            _service = service;
        }

        protected override void Handle(PersonCreateCommand request)
        {
            var x = new PersonWriteDto
            {
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                Profession = request.Person.Profession,
                Birthdate = request.Person.Birthdate,
                Email = request.Person.Email,
                Hobbies = request.Person.Hobbies
            };

            _service.Create(x);
        }
    }
}