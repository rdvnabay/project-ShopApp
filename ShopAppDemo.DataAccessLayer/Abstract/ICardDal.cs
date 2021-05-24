using ShopAppDemo.Core.DataAccessLayer;
using ShopAppDemo.Entities;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface ICardDal : IEntityRepository<Card>
    {
        Card GetCardByUserId(string userId);
        void RemoveFromCard(int cardId, int productId);
    }
}
