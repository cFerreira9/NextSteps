﻿using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    internal class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public void Create(TEntity p)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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