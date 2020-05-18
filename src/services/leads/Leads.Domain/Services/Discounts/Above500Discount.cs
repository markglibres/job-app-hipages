using Leads.Domain.Entities;
using Leads.Domain.Services.Seedwork;

namespace Leads.Domain.Services.Discounts
{
    public class Above500Discount : IDiscountService
    {
        public void ApplyDiscount( Job job )
        {
            if ( job.Price <= 500 ) return;

            var price = job.Price;
            var discount = price - price * ( decimal ) 0.1;

            job.SetPrice( discount );
        }
    }
}