using MediatR;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetAllQueryHandler : RequestHandler<PersonGetAllQuery, IEnumerable<PersonReadDto>>
    {
        private IPersonService _service;

        public PersonGetAllQueryHandler(IPersonService service)
        {
            _service = service;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonGetAllQuery request)
        {
            var list = _service.GetAll();

            var personList = new List<PersonReadDto>();

            foreach (var item in list)
            {
                var hobList = new List<HobbyDto>();

                foreach (var hobb in item.Hobbies)
                {
                    hobList.Add(new HobbyDto
                    {
                        Id = hobb.Id,
                        Name = hobb.Name,
                        Type = hobb.Type
                    });
                }

                personList.Add(new PersonReadDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Profession = item.Profession,
                    Birthdate = item.Birthdate.ToString(),
                    Email = item.Email,
                    Hobbies = hobList
                });
            }
            return personList;
        }
    }
}