using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class PersonService : IPersonService
    {
        public void Create(Person p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            throw new NotImplementedException();
        }

        public void Update(Person p)
        {
            throw new NotImplementedException();
        }
    }
}
