using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem>Items { get; set; } = new List<BasketLineItem>();
//first part declares, second part instantiates


        public void AddItem (Books book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == book.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
                
            }


        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);
            //probably need to fix this equation
            return sum;
        }


    }



    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Books Books { get; set; }

        public int Quantity { get; set; }

    }

}
