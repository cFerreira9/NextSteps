using Next.Steps.Domain.Entities;
using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Create(TEntity p);

        void Update(TEntity p);

        void Delete(int id);

        TEntity GetByID(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Search(string firstName, string lastName = "");

    }
}
