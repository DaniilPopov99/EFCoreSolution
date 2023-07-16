using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UoW.Models.OrganizationEntities;

namespace UoW.Configurations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(o => o.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Name).IsRequired();

            builder.HasOne(h => h.Address)
                .WithOne()
                .HasForeignKey<Organization>(x => x.AddressId);
        }
    }
}
