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
    public class PersonGetByIdQueryHandler : RequestHandler<PersonGetByIdQuery, PersonReadDto>
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonGetByIdQueryHandler(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override PersonReadDto Handle(PersonGetByIdQuery request)
        {
            var personResult = _service.GetByID(request.Id);

            if (personResult != null)
            {
                return _mapper.Map<Person, PersonReadDto>(personResult);
            }
            else
            {
                return null;
            }
        }
    }
}