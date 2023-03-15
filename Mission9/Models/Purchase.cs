using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }


        [Required(ErrorMessage ="Name invalid: Please enter.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Address invalid: Please enter.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage="City invalid: Please enter.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State invalid: Please enter.")]
        public string State { get; set; }
        [Required(ErrorMessage ="Zipcode invalid: Please enter.")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Country invalid: Please enter.")]
        public string Country { get; set; }
    }
}
