using AutoMapper;
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
    public class PersonGetAllQueryHandler : RequestHandler<PersonGetAllQuery, IEnumerable<PersonReadDto>>
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonGetAllQueryHandler(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonGetAllQuery request)
        {
            var list = _service.GetAll();

            if (list != null)
            {
                return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonReadDto>>(list);
            }
            else
            {
                return null;
            }
        }
    }
}