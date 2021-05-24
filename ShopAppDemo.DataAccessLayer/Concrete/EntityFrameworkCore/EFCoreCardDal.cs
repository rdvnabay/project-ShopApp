using Microsoft.EntityFrameworkCore;
using ShopAppDemo.Core.DataAccess.EntityFramework;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;
using System.Linq;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreCardDal : EfEntityRepositoryBase<Card, ShopAppContext>, ICardDal
    {
        #region Method=> GetCardByUserId
        public Card GetCardByUserId(string userId)
        {
            using (var context = new ShopAppContext())
            {
                return context.Cards
           .Include(x => x.CardItems)
           .ThenInclude(x => x.Product)
           .FirstOrDefault(x => x.UserId == userId);
            }
        }
        #endregion

        #region Method=> RemoveFromCard
        public void RemoveFromCard(int cardId, int productId)
        {
            using (var context = new ShopAppContext())
            {
                var cmd = @"delete from CardItem where CardId=@p0 and ProductId=@p1";
              //  context.Database.ExecuteSqlCommand(cmd, cardId, productId);
            }
        }
        #endregion

        #region Override Method=> Update
        //public override void Update(Card entity)
        //{
        //    _context.Cards.Update(entity);
        //    _context.SaveChanges();
        //}
        #endregion
    }
}
