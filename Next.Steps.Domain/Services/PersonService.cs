using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private IPersonRepository _prepo;

        public PersonService(IPersonRepository prepo) : base(prepo)
        {
            _prepo = prepo;
        }

        //TODO: person service
    }
}