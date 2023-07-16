using Microsoft.EntityFrameworkCore;
using UoW.Configurations;
using UoW.Models.CompanyEntities;

namespace UoW.Contexts
{
    public class CompaniesContext : DbContext
    {
        public CompaniesContext(DbContextOptions<CompaniesContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts").HasKey(h => h.Id);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
