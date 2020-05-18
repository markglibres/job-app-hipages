using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Leads.Infrastructure.MySqlDatabase.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseSnakeCase( this IMutableModel model )
        {
            foreach ( var entity in model.GetEntityTypes() )
            {
                entity.SetTableName( entity.GetTableName().ToSnakCase() );

                foreach ( var property in entity.GetProperties() )
                {
                    property.SetColumnName( property.GetColumnName().ToSnakCase() );
                }

                foreach ( var property in entity.GetForeignKeys() )
                {
                    property.SetConstraintName( property.GetConstraintName().ToSnakCase() );
                }

                foreach ( var property in entity.GetIndexes() )
                {
                    property.SetName( property.GetName().ToSnakCase() );
                }
            }
        }
    }
}