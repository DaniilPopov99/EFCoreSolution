using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UoW.Models.CompanyEntities;

namespace UoW.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.HasKey(o => o.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Name).IsRequired();

            builder.HasOne(h => h.Company)
                .WithMany(w => w.People)
                .HasForeignKey(f => f.CompanyId);

            builder.HasMany(c => c.Posts)
                .WithMany(p => p.People)
                .UsingEntity(
                    "PeopleToPosts",
                    l => l.HasOne(typeof(Post)).WithMany().HasForeignKey("PostId").HasPrincipalKey(nameof(Post.Id)),
                    r => r.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(Person.Id)),
                    j => j.HasKey("PostId", "PersonId"));
        }
    }
}
