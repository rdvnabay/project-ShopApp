using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CardItem> CardItems { get; set; }
    }
}
