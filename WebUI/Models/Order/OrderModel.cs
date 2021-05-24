using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models.Order
{
    public class OrderModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Card Name")]
        public string CardName { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name ="Month")]
        public string ExpirationMonth { get; set; }

        [Display(Name = "Year")]
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }

        public CardModel CardModel { get; set; }


    }
}
