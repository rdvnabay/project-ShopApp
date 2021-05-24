using Core.Utilities.Results;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface ICardService
    {
        IResult AddToCard(string userId, int productId, int quantity);
        IDataResult<Card> GetCardByUserId(string userId);
        IResult InitializeCard(string userId);  
        IResult RemoveFromCard(string userId, int productId);
    }
}
