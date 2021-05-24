using Core.Utilities.Results;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult AddToCard(string userId, int productId, int quantity)
        {
           var card =_cardDal.GetCardByUserId(userId);
            if (card!=null)
            {
                var index = card.CardItems.FindIndex(x => x.ProductId == productId);
                if (index<0)
                {
                    card.CardItems.Add(new CardItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CardId = card.Id,
                    });
                }
                else
                {
                    card.CardItems[index].Quantity += quantity;
                }
                _cardDal.Update(card);
            }
            return new SuccessResult();
        }
        public IDataResult<Card> GetCardByUserId(string userId)
        {
            var data= _cardDal.GetCardByUserId(userId);
            return new SuccessDataResult<Card>(data);
        }
        public IResult InitializeCard(string userId)
        {
            _cardDal.Add(new Card()
            {
                UserId = userId
            });
            return new SuccessResult();
        }
        public IResult RemoveFromCard(string userId, int productId)
        {
            var card = _cardDal.GetCardByUserId(userId);
            if (card!=null)
            {
                _cardDal.RemoveFromCard(card.Id, productId);
            }
            return new SuccessResult();
        }
    }
}
