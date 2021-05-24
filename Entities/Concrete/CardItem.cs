using Core.Entities;

namespace ShopAppDemo.Entities.Concrete
{
    public class CardItem:IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Card Card { get; set; }
        public int CardId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

   
    }
}