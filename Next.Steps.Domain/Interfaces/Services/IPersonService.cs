using Next.Steps.Domain.Entities;
using System.Collections.Generic;

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
