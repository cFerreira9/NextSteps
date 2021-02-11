using Next.Steps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Domain.Interfaces.Services
{
    interface IPersonService
    {
        void Create(Person p);
        void Update(Person p);
        void Delete(int id);
        Person GetByID(int id);
        IEnumerable<Person> GetAll();
        IEnumerable<Person> Search(string firstName, string lastName = "");

    }
}
