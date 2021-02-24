using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonUpdateCommandHandler : RequestHandler<PersonUpdateCommand>
    {
        private IPersonService _service;

        public PersonUpdateCommandHandler(IPersonService service)
        {
            _service = service;
        }

        protected override void Handle(PersonUpdateCommand request)
        {
            var hobList = new List<Hobby>();

            foreach (var item in request.Person.Hobbies)
            {
                hobList.Add(new Hobby
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type
                });
            }

            var person = new Person
            {
                Id = request.Person.Id,
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                Birthdate = (DateTime)request.Person.Birthdate,
                Email = request.Person.Email,
                Hobbies = hobList
            };

            _service.Update(person);
        }
    }
}