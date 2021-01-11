using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface ICardService:IRepositoryService<Card>
    {
        void InitializeCard(string userId);
        Card GetCardByUserId(string userId);

        void AddToCard(string userId, int productId, int quantity);
        void RemoveFromCard(string userId, int productId);
    }
}
