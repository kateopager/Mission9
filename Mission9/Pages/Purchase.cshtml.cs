using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructure;
using Mission9.Models;

namespace Mission9.Pages
{
    public class PurchaseModel : PageModel
    {
        //setting up instances

        private IBookstoreRepo repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel(IBookstoreRepo temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }


        public IActionResult OnPost(int bookId, string returnUrl)
        {

            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
           

        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == bookId).Books);
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
