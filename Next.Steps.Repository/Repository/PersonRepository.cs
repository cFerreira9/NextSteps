using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Next.Steps.Repository.EF.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly NextStepsContext _context;

        public PersonRepository(NextStepsContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Person> GetAll()
        {
            return _context.People.Include(p => p.Hobbies).ToList();
        }

        public override Person GetById(int id)
        {
            return _context.People
                .Where(p => p.Id == id)
                .Include(p => p.Hobbies)
                .FirstOrDefault();
        }

        public override bool Update(Person p)
        {
            try
            {
                _context.People.Update(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //TODO Escrever logger exception ex
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = GetById(id);
                _context.People.Remove(result);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO Escrever logger exception ex
                return false;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName)
        {
            return _context.People.Where(l =>
                (!string.IsNullOrWhiteSpace(firstName) && l.FirstName == firstName)
                || (!string.IsNullOrWhiteSpace(lastName) && l.LastName == lastName))
                .Include(p => p.Hobbies);
        }
    }
}