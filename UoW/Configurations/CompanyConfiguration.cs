using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UoW.Models.CompanyEntities;

namespace UoW.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(o => o.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Name).IsRequired();
        }
    }
}
