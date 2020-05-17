using System;
using System.Collections.Generic;
using System.Text;
using Leads.Domain.Constants;
using Leads.Domain.Entities;
using Leads.Domain.ValueObjects;
using Leads.Infrastructure.MySqlDatabase.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leads.Infrastructure.MySqlDatabase.Entities
{
    public class Jobs : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

            builder
                .OwnsOne(
                    e => e.Contact,
                    contact =>
                    {
                        contact.Property(c => c.Email)
                            .HasColumnName($"{nameof(Contact)}{nameof(Contact.Email)}".ToSnakCase())
                            .HasColumnType("varchar(255)");
                        contact.Property(c => c.Name)
                            .HasColumnName($"{nameof(Contact)}{nameof(Contact.Name)}".ToSnakCase())
                            .HasColumnType("varchar(255)"); ;
                        contact.Property(c => c.Phone)
                            .HasColumnName($"{nameof(Contact)}{nameof(Contact.Phone)}".ToSnakCase())
                            .HasColumnType("varchar(255)"); ;
                    });

            builder
                .Property(e => e.CreatedAt)
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.UpdatedAt)
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            builder
                .Property(e => e.Description)
                .HasColumnType("text");

            builder
                .Property(e => e.Price)
                .HasColumnType("int(3)");

            builder
                .HasOne(e => e.Category)
                .WithMany();

            builder
                .HasOne(e => e.Suburb)
                .WithMany();

            builder
                .Property(e => e.Status)
                .HasColumnType("varchar(50)")
                .HasConversion(new EnumToStringConverter<JobStatus>());

            builder
                .HasIndex(e => e.ReferenceId);
        }
    }
}
