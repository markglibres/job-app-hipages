using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Infrastructure.MySqlDatabase.Entities
{
    public class Suburbs : IEntityTypeConfiguration<Suburb>
    {
        public void Configure(EntityTypeBuilder<Suburb> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);
            builder
                .HasIndex(e => e.PostCode)
                .HasName("idx_suburbs_postcode");
            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(255)");
            builder
                .Property(e => e.PostCode)
                .HasColumnType("varchar(4)");

            builder
                .HasIndex(e => new {e.Name, e.PostCode});
        }
    }
}