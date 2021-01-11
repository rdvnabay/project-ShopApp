using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public List<CardItemModel> CardItems { get; set; }

        public double? TotalPrice()
        {
            return CardItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
