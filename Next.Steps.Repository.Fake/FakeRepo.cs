using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Next.Steps.Repository.Fake
{
    public class FakeRepo : IPersonRepository
    {

        private List<Person> list = new List<Person>();

        public bool Create(Person p)
        {
            var index = list.IndexOf(p);
            if (index != -1)
            {
                list.Add(p);
                return true;
            }

            return false;
        }

        public bool Update(Person p)
        {
            var index = list.IndexOf(p);

            if (index >= 0)
            {
                list[index] = p;
                return true;
            }

            return false;
        }

        public bool Delete(Person p)
        {
            var index = list.IndexOf(p);

            if (index >= 0)
            {
                list.Remove(p);
                return true;
            }

            return false;
        }

        public IEnumerable<Person> GetAll()
        {
            return list;
        }

        public Person GetByID(int id)
        {
            var index = list.FindIndex(l => l.Id == id);
            if (index >= 0)
            {
                return list[index];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            return list.FindAll(l => l.FirstName == firstName || (lastName != "" && l.LastName == lastName));

        }

    }
}
