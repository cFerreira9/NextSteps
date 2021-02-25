using AutoMapper;
using MediatR;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonSearchQueryHandler : RequestHandler<PersonSearchQuery, IEnumerable<PersonReadDto>>
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonSearchQueryHandler(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonSearchQuery request)
        {
            var list = _service.Search(request.Firstname, request.Lastname);

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