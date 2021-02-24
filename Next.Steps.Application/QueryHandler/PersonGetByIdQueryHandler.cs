using MediatR;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetByIdQueryHandler : RequestHandler<PersonGetByIdQuery, PersonReadDto>
    {
        private IPersonService _service;

        public PersonGetByIdQueryHandler(IPersonService service)
        {
            _service = service;
        }

        protected override PersonReadDto Handle(PersonGetByIdQuery request)
        {
            var personResult = _service.GetByID(request.Id);

            if (personResult != null)
            {

                var hobList = new List<HobbyDto>();

                foreach (var hobb in personResult.Hobbies)
                {
                    hobList.Add(new HobbyDto
                    {
                        Id = hobb.Id,
                        Name = hobb.Name,
                        Type = hobb.Type
                    });
                }

                var personDto = new PersonReadDto
                {
                    Id = personResult.Id,
                    FirstName = personResult.FirstName,
                    LastName = personResult.LastName,
                    Profession = personResult.Profession,
                    Birthdate = personResult.Birthdate,
                    Email = personResult.Email,
                    Hobbies = hobList
                };

                return personDto;
            }
            else
            {
                return null;
            }
        }
    }
}