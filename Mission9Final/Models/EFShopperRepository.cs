using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission9Final.Models
{
    public class EFShopperRepository : IShopperRepository
    {
        private BookContext context;

        public EFShopperRepository(BookContext temp)
        {
            context = temp;
        }

        public IQueryable<Shopper> Shoppers => context.Shoppers.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveShopper(Shopper shopper)
        {
            // Select Lines and its book info
            context.AttachRange(shopper.Lines.Select(x => x.Book));

            // If there is no shopperId, just add it.
            if (shopper.ShopperId == 0)
            {
                context.Shoppers.Add(shopper);
            }

            context.SaveChanges();
        }
    }
}
