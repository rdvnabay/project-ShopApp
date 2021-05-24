using Core.Entities;
using System.Collections.Generic;

namespace ShopAppDemo.Entities.Concrete
{
    public class Card:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CardItem> CardItems { get; set; }
    }
}
