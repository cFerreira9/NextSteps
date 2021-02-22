using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    internal class PersonService : BaseService<Person>, IPersonService
    {
        public Person GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            throw new NotImplementedException();
        }
    }
}