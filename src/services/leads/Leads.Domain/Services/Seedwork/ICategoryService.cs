using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services.Seedwork
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync( int id, string name, int parentCategoryId );
        Task<bool> IsExistsAsync( string name, int parentCategoryId );
    }
}