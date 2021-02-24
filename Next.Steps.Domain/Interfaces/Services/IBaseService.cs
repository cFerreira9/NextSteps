﻿using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        bool Create(TEntity p);

        bool Update(TEntity p);

        bool Delete(TEntity p);

        IEnumerable<TEntity> GetAll();

        TEntity GetByID(int id);

        IEnumerable<TEntity> Search(string firstName, string lastName = "");
    }
}