using ShopAppDemo.Core.DataAccess;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface ICardDal : IEntityRepository<Card>
    {
        Card GetCardByUserId(string userId);
        void RemoveFromCard(int cardId, int productId);
    }
}
