using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models.Order
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
