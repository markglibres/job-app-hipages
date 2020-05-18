using Leads.Application.Services.JobQuery;
using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Infrastructure.MySqlDatabase.Entities
{
    public class JobsInfoConfiguration : IEntityTypeConfiguration<JobInfo>
    {
        public void Configure( EntityTypeBuilder<JobInfo> builder )
        {
            builder.HasKey( e => e.Id )
                .HasAnnotation( "MySql:ValueGeneratedOnAdd", true );

            builder.Property( e => e.CreatedAt )
                .HasColumnType( "TIMESTAMP" );

            builder.Property( e => e.Description )
                .HasColumnType( "text" );

            builder.Property( e => e.Price )
                .HasColumnType( "int(3)" );

            builder.Property( e => e.JobStatus )
                .HasColumnType( "varchar(50)" );

            builder.Property( e => e.ContactName )
                .HasColumnType( "varchar(255)" );

            builder.Property( e => e.ContactPhone )
                .HasColumnType( "varchar(255)" );

            builder.Property( e => e.ContactEmail )
                .HasColumnType( "varchar(255)" );

            builder.Property( e => e.CategoryName )
                .HasColumnType( "varchar(255)" );

            builder.Property( e => e.SuburbName )
                .HasColumnType( "varchar(255)" );

            builder.Property( e => e.SuburbPostcode )
                .HasColumnType( "varchar(4)" );

            builder.HasIndex( e => e.ReferenceId );
            builder.HasIndex( e => e.JobStatus );
        }
    }
}