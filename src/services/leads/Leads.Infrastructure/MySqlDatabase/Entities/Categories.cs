using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Infrastructure.MySqlDatabase.Entities
{
    public class Categories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

            builder
                .Property(e => e.ParentCategoryId)
                .HasColumnName("parent_category_id");

            builder
                .HasIndex(e => e.ParentCategoryId)
                .HasName("idx_categories_parent_category");

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(255)");

            builder
                .HasIndex(e => new {e.Name, e.ParentCategoryId});
        }
    }
}