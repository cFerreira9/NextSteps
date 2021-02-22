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

        public DbSet<Hobby> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JN31U5B\SQLEXPRESS;
                Initial Catalog=Next_Steps_Project;
                Persist Security Info=True;
                User id=sa;
                Password=Password1994");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}