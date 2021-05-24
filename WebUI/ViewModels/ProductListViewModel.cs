using ShopAppDemo.Entities.Concrete;
using System.Collections.Generic;

namespace ShopAppDemo.WebUI.Models
{
    public class ProductListViewModel
    {
      public PagingInfo PagingInfo { get; set; }
      public Product Product { get; set; }
      public List<Product> Products { get; set; }
     }
}
