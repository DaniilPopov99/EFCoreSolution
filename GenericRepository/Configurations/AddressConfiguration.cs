using GenericRepository.Models.OrganizationEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(o => o.Id);

            builder.ToTable("Addresses");

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Name).IsRequired();
        }
    }
}
