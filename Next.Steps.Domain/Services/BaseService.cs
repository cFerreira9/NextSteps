using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repo;

        public BaseService(IBaseRepository<TEntity> repo)
        {
            _repo = repo;
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

        public bool Delete(TEntity p)
        {
            if (p == null)
            {
                return false;
            }
            else
            {
                _repo.Delete(p);
                return true;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public TEntity GetByID(int id)
        {
            return _repo.GetById(id);
        }
    }
}