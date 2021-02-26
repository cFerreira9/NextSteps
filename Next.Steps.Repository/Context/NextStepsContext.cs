using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}