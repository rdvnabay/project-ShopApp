using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class CardManager : ICardService
    {
        #region Variable
        private ICardDal _cardDal;
        #endregion

        #region Constructor
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        #endregion

        #region Method=> AddToCard
        public void AddToCard(string userId, int productId, int quantity)
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
        }
        #endregion

        #region Method=> InitializeCard
        public void InitializeCard(string userId)
        {
            _cardDal.Add(new Card()
            {
                UserId = userId
            });

        }
        #endregion

        #region Method=> RemoveFromCard
        public void RemoveFromCard(string userId, int productId)
        {
            var card = _cardDal.GetCardByUserId(userId);
            if (card!=null)
            {
                _cardDal.RemoveFromCard(card.Id, productId);
            }
        }
        #endregion

        #region Methods=>CRUD
        public IEnumerable<Card> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Create(Card entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Card entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Card entity)
        {
            throw new NotImplementedException();
        }
        #endregion


        public IEnumerable<Card> GetAllFilter(Expression<Func<Card, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Card GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Card GetCardByUserId(string userId)
        {
            return _cardDal.GetCardByUserId(userId);
        }

        public Card GetOneFilter(Expression<Func<Card, bool>> filter = null)
        {
            throw new NotImplementedException();
        }  
    }
}
