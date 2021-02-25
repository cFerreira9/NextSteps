﻿using Next.Steps.Domain.Entities;
using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Services
{
    public interface IPersonService : IBaseService<Person>
    {
        IEnumerable<Person> Search(string firstName, string lastName);
    }
}