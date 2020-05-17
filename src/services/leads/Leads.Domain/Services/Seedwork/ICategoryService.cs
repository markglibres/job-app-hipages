using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services
{
    public interface ICategoryService
    {
        Task<Category> Create(int id, string name, int parentCategoryId);
        Task<bool> IsExists(string name, int parentCategoryId);
    }
}