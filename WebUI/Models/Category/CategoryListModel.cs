using ShopAppDemo.Entities.Concrete;
using System.Collections.Generic;

namespace ShopAppDemo.WebUI.Models
{
    public class CategoryListModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
