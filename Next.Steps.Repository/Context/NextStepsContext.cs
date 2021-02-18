using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;
using System;
using System.Linq;

namespace Next.Steps.Repository.Context
{
    public class NextStepsContext : DbContext
    {
        public NextStepsContext() : base()
        {
        }

        public NextStepsContext(DbContextOptions<NextStepsContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Hobby> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JN31U5B\SQLEXPRESS;
                Initial Catalog=Next_Steps_Project;
                Persist Security Info=True;
                User id=sa
                password=Next123");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataSaves") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataSaves").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataSaves").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}