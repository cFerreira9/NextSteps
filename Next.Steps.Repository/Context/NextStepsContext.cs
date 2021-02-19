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
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JN31U5B;
                Initial Catalog=Next_Steps_Project;
                Persist Security Info=True;
                User id=sa;
                Password=Password1994");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("nextSteps");

            modelBuilder.Entity<Person>( entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Profession).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Hobbies);
            }
            );
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