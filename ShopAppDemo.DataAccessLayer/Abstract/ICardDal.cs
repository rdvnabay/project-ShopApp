using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface ICardDal : IRepository<Card>
    {
        Card GetCardByUserId(string userId);
        void RemoveFromCard(int cardId, int productId);
    }
}
