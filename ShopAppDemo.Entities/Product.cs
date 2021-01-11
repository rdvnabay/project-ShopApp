using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
