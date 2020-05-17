using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services
{
    public interface ISuburbService
    {
        Task<Suburb> Create(int id, string name, string postCode);
        Task<bool> IsExists(string name, string postCode);
    }
}