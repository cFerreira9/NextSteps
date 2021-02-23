using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private IBaseRepository<TEntity> _frepo;

        public BaseService(IBaseRepository<TEntity> frepo)
        {
            _frepo = frepo;
        }

        public bool Create(TEntity p)
        {


            if (p == null)
            {
                return false;
            }
            else
            {
                _frepo.Create(p);
                return true;
            }
        }

        public bool Update(TEntity p)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Search(string firstName, string lastName = "")
        {
            throw new NotImplementedException();
        }
    }
}