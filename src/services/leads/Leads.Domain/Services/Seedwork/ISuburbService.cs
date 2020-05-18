using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services
{
    public interface ISuburbService
    {
        Task<Suburb> CreateAsync( int id, string name, string postCode );
        Task<bool> IsExistsAsync( string name, string postCode );
    }
}