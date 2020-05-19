using BizzPo.Core.Infrastructure.Repository.EntityFramework;
using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Infrastructure.MySqlDatabase.Entities
{
    public class JobEventsConfiguration : IEntityTypeConfiguration<JobEvent>
    {
        public void Configure( EntityTypeBuilder<JobEvent> builder )
        {
            builder.HasKey(e => e.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

            builder.HasIndex(e => e.EventId);
            builder.HasIndex( e => e.ReferenceId );
            builder.HasIndex( e => e.EventName );

            builder.Property( e => e.DateCreated )
                .HasColumnType( "TIMESTAMP" );

            builder.Property( e => e.EventData )
                .HasColumnType( "JSON" )
                .HasConversion( new DynamicPropertyValueConverter() );
        }
    }
}