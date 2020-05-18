using Ardalis.GuardClauses;
using Leads.Domain.Entities.Seedwork;
using Leads.Domain.Extensions;
using Newtonsoft.Json;

namespace Leads.Domain.Entities
{
    public class Suburb : IDbEntity
    {
        [JsonConstructor]
        private Suburb() { }

        public Suburb( string name, string postCode )
        {
            Guard.Against.Empty( name, nameof( Name ) );
            Guard.Against.Empty( postCode, nameof( PostCode ) );

            Name = name;
            PostCode = postCode;
        }

        public Suburb( int id, string name, string postCode )
            : this( name, postCode )
        {
            Guard.Against.ZeroOrNegative( id, nameof( Id ) );
            Id = id;
        }

        public string Name { get; private set; }
        public string PostCode { get; private set; }
        public int Id { get; private set; }
    }
}