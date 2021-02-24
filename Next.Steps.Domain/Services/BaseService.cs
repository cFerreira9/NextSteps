using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    //TODO: Para revisão
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
            if (p == null)
            {
                return false;
            }
            else
            {
                _frepo.Update(p);
                return true;
            }
        }

        public bool Delete(TEntity p)
        {
            if (p == null)
            {
                return false;
            }
            else
            {
                _frepo.Delete(p);
                return true;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _frepo.GetAll();
        }

        public TEntity GetByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                return _frepo.GetByID(id);
            }
        }

        public IEnumerable<TEntity> Search(string firstName, string lastName = "")
        {
            if (firstName == "" || lastName =="")
            {
                return null;
            }
            else if (firstName == "")
            {
                return _frepo.Search(lastName);
            }
            else if (lastName == "")
            {
                return _frepo.Search(firstName);
            }
            else
            {
                return _frepo.Search(firstName, lastName);
            }
        }
    }
}