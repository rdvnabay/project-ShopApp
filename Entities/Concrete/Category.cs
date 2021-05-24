using Core.Entities;
using System.Collections.Generic;

namespace ShopAppDemo.Entities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
