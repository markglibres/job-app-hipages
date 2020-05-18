using Ardalis.GuardClauses;
using Leads.Domain.Entities.Seedwork;
using Leads.Domain.Extensions;
using Newtonsoft.Json;

namespace Leads.Domain.Entities
{
    public class Category : IDbEntity
    {
        [JsonConstructor]
        private Category() { }

        public Category( string name, int parentCategoryId )
        {
            Guard.Against.Empty( name, nameof( Name ) );

            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public Category( int id, string name, int parentCategoryId )
            : this( name, parentCategoryId )
        {
            Guard.Against.ZeroOrNegative( id, nameof( Id ) );
            Id = id;
        }

        public string Name { get; private set; }
        public int ParentCategoryId { get; private set; }
        public int Id { get; private set; }
    }
}