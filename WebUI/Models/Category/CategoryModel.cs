using ShopAppDemo.Entities.Concrete;
using System.Collections.Generic;

namespace ShopAppDemo.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
