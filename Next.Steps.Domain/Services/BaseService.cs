using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    //TODO: Verificar o Search
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private IBaseRepository<TEntity> _repo;

        public BaseService(IBaseRepository<TEntity> frepo)
        {
            _repo = frepo;
        }

        public bool Create(TEntity p)
        {
            if (p == null)
            {
                return false;
            }
            else
            {
                _repo.Create(p);
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
                _repo.Update(p);
                return true;
            }
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public TEntity GetByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                return _repo.GetById(id);
            }
        }

        public IEnumerable<TEntity> Search(string firstName, string lastName = "")
        {
            if (firstName == "" || lastName == "")
            {
                return null;
            }
            else if (firstName == "")
            {
                return _repo.Search(lastName);
            }
            else if (lastName == "")
            {
                return _repo.Search(firstName);
            }
            else
            {
                return _repo.Search(firstName, lastName);
            }
        }
    }
}