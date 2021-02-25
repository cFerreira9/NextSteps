using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Next.Steps.Repository.Fake
{
    public class FakeRepo : IPersonRepository
    {
        private static List<Person> personList = new List<Person>();
        private static int personId = 1;
        private static int hobbyId = 1;

        public FakeRepo()
        {
            var ler = new Hobby
            {
                Name = "Ler",
                Type = "Cultura"
            };

            var jogar = new Hobby
            {
                Name = "Jogar",
                Type = "Video-Jogos"
            };

            var dormir = new Hobby
            {
                Name = "Dormir",
                Type = "Perguiça"
            };

            var carlos = new Person
            {
                FirstName = "Carlos",
                LastName = "Ferreira",
                Birthdate = DateTime.Now,
                Email = "ad@hotmail.com",
                Profession = "dev",
                Hobbies = new List<Hobby>() { ler }
            };

            var monteiro = new Person
            {
                FirstName = "Pedro",
                LastName = "Monteiro",
                Birthdate = DateTime.Now,
                Email = "fg@hotmail.com",
                Profession = "dev",
                Hobbies = new List<Hobby>() { dormir }
            };

            var mateus = new Person
            {
                FirstName = "Pedro",
                LastName = "Mateus",
                Birthdate = DateTime.Now,
                Email = "ty@hotmail.com",
                Profession = "dev",
                Hobbies = new List<Hobby>() { jogar }
            };

            Create(carlos);
            Create(monteiro);
            Create(mateus);
        }

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

        public bool Delete(int id)
        {
            var index = personList.FindIndex(x => x.Id == id);

            if (index >= 0)
            {
                personList.RemoveAt(index);
                return true;
            }

            return false;
        }

        public IEnumerable<Person> GetAll()
        {
            return personList;
        }

        public Person GetById(int id)
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

        public IEnumerable<Person> Search(string firstName, string lastName)
        {
            return personList.FindAll(l =>
                (!string.IsNullOrWhiteSpace(firstName) && l.FirstName == firstName)
                || (!string.IsNullOrWhiteSpace(lastName) && l.LastName == lastName));
        }
    }
}