using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UoW.Models.OrganizationEntities;

namespace UoW.Configurations
{
    internal class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Emails");

            builder.HasKey(o => o.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Organization)
                .WithMany(w => w.Emails)
                .HasForeignKey(f => f.OrganizationId);
        }
    }
}
