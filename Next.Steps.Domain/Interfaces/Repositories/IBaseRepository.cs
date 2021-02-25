using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Create(TEntity p);

        bool Update(TEntity p);

        bool Delete(TEntity p);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}