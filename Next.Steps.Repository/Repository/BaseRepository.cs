using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next.Steps.Repository.EF.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly NextStepsContext _context;

        public BaseRepository(NextStepsContext context)
        {
            _context = context;
        }

        public virtual bool Create(TEntity p)
        {
            _context.Set<TEntity>().Add(p);
            _context.SaveChanges();
            return true;
        }

        public virtual bool Update(TEntity p)
        {
            _context.Set<TEntity>().Update(p);
            _context.SaveChanges();
            return true;
        }

        public virtual bool Delete(TEntity p)
        {
            _context.Set<TEntity>().Remove(p);
            _context.SaveChanges();
            return true;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}