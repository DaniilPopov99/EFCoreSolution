using GenericRepository.Configurations;
using GenericRepository.Models.OrganizationEntities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Contexts
{
    public class OrganizationsContext : DbContext
    {
        public OrganizationsContext(DbContextOptions<OrganizationsContext> options) : base(options) 
        {
        }

        public DbSet<Address> Address { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<Organization> Organization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        }
    }
}
