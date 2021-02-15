using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity p);

        void Update(TEntity p);

        void Delete(TEntity p);

        TEntity GetByID(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Search(string firstName, string lastName = "");
    }
}
