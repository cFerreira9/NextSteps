using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Next.Steps.Repository.Fake
{
    public class FakeRepo : IPersonRepository
    {
        private static List<Person> personList = new List<Person>();

        //private static List<Hobby> hobbyList = new List<Hobby>();

        private static int personId = 1;

        private static int hobbyId = 1;

        public bool Create(Person p)
        {
            p.Id = personId;

            var index = personList.IndexOf(p);
            if (index < 0)
            {
                foreach (var item in p.Hobbies)
                {
                    item.Id = hobbyId;
                    hobbyId++;
                }

                personList.Add(p);
                personId++;
                return true;
            }
            return false;
        }

        public bool Update(Person p)
        {
            var index = personList.FindIndex(x => x.Id == p.Id);

            if (index >= 0)
            {
                personList[index] = p;
                return true;
            }

            return false;
        }

        public bool Delete(Person p)
        {
            var index = personList.IndexOf(p);

            if (index >= 0)
            {
                personList.Remove(p);
                return true;
            }

            return false;
        }

        public IEnumerable<Person> GetAll()
        {
            return personList;
        }

        public Person GetByID(int id)
        {
            var index = personList.FindIndex(l => l.Id == id);
            if (index >= 0)
            {
                return personList[index];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            return personList.FindAll(l => l.FirstName == firstName || (lastName != "" && l.LastName == lastName));
        }
    }
}