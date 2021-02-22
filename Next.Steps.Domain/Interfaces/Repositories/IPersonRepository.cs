﻿using Next.Steps.Domain.Entities;
using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetByID(int id);

        IEnumerable<Person> Search(string firstName, string lastName = "");
    }
}