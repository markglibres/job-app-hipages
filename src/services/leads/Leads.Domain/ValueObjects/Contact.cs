using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using Leads.Domain.Extensions;
using Newtonsoft.Json;

namespace Leads.Domain.ValueObjects
{
    public class Contact
    {
        [JsonConstructor]
        private Contact() { }

        public Contact( string name, string phone, string email )
        {
            Guard.Against.Empty<DomainException>( name, nameof( Name ) );
            Guard.Against.Empty<DomainException>( phone, nameof( Phone ) );
            Guard.Against.Empty<DomainException>( email, nameof( Email ) );

            Name = name;
            Phone = phone;
            Email = email;
        }

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
    }
}