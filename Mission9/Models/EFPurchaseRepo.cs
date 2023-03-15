using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFPurchaseRepo : IPurchaseRepo
    {
        private BookstoreContext context;
        public EFPurchaseRepo(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchases => context.Purchase.Include(x => x.Lines).ThenInclude(x => x.Books);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Books));

            if (purchase.PurchaseId == 0)
            {
                context.Purchase.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
