using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next.Steps.Repository.Fake
{
    public class FakeRepo : IPersonRepository
    {

        private List<Person> list = new List<Person>();

        public bool Create(Person p)
        {
            //Devolvel um bool os metodos

            var index = list.IndexOf(p);
            if (index != -1)
            {
                list.Add(p);
            }
        }

        public bool Update(Person p)
        {
            // devolver bool quando n encontrar
            var index = list.IndexOf(p);

            if (index >= 0)
            {
                list[index] = p;
            }

        }

        public bool Delete(Person p)
        {
            //verificar se existe
            // devolver bool quando n encontrar

            list.Remove(p);
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
