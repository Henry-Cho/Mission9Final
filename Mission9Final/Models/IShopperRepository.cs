using System;
using System.Linq;

namespace Mission9Final.Models
{
    public interface IShopperRepository
    {
        IQueryable<Shopper> Shoppers { get; }

        void SaveShopper(Shopper shopper);
    }
}
