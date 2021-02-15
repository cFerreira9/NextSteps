using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Repository.Context
{
    public class NextStepsContext : DbContext
    {

        public NextStepsContext()
        {

        }

        public NextStepsContext(DbContextOptions<NextStepsContext> options) : base(options) { }

    }
}
