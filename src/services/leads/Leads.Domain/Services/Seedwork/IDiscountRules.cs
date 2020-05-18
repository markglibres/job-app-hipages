using Leads.Domain.Entities;

namespace Leads.Domain.Services.Seedwork
{
    public interface IDiscountService
    {
        void ApplyDiscount( Job job );
    }
}