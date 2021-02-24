using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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
            var hobList = new List<Hobby>();

            foreach (var item in request.Person.Hobbies)
            {
                hobList.Add(new Hobby
                {
                    Name = item.Name,
                    Type = item.Type
                });
            }

            var person = new Person
            {
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                Profession = request.Person.Profession,
                Birthdate = (DateTime)request.Person.Birthdate,
                Email = request.Person.Email,
                Hobbies = hobList
            };

            _service.Create(person);
        }
    }
}