using Core.Entities;

namespace ShopAppDemo.Entities.Concrete
{
    public class ProductCategory:IEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
