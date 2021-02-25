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

        public bool Delete(int id)
        {
            return _prepo.Delete(id);
        }

        public IEnumerable<Person> Search(string firstName, string lastName)
        {
            if (firstName == "" && lastName == "")
            {
                return null;
            }
            else
            {
                return _prepo.Search(firstName, lastName);
            }
        }
    }
}