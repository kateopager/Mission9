using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface IPurchaseRepo
    {
        IQueryable<Purchase> Purchases { get; }
        public void SavePurchase(Purchase purchase);
    }
}
