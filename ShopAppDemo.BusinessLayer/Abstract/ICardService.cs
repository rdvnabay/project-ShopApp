using ShopAppDemo.Entities;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface ICardService
    {
        void InitializeCard(string userId);
        Card GetCardByUserId(string userId);

        void AddToCard(string userId, int productId, int quantity);
        void RemoveFromCard(string userId, int productId);
    }
}
