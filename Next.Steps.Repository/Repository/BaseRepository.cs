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
    class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly NextStepsContext _nextStepsContext;

        public BaseRepository(NextStepsContext _nextStepsContext)
        {
            this._nextStepsContext = _nextStepsContext;
        }

        public bool Create(TEntity p)
        {
            try
            {
                _nextStepsContext.Set<TEntity>().Add(p);
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(TEntity p)
        {
            try
            {
                _nextStepsContext.Entry(p).State = EntityState.Modified;
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(TEntity p)
        {
            try
            {
                _nextStepsContext.Set<TEntity>().Remove(p);
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _nextStepsContext.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            return _nextStepsContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Search(string firstName, string lastName = "")
        {
            //return _nextStepsContext.Set<TEntity>().ToList().FindAll(x => x.);
        }

    }
}
