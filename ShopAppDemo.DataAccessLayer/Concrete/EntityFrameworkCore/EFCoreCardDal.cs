using Microsoft.EntityFrameworkCore;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreCardDal:BaseRepository<Card>, ICardDal
    {
        #region Variables
        private readonly ShopAppContext _context;
        #endregion

        #region Constructor
        public EFCoreCardDal(ShopAppContext context):base(context)
        {
            _context = context;
        }
        #endregion

        #region Method=> GetCardByUserId
        public Card GetCardByUserId(string userId)
        {
            return _context.Cards
                .Include(x => x.CardItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.UserId == userId);
        }
        #endregion

        #region Method=> RemoveFromCard
        public void RemoveFromCard(int cardId, int productId)
        {
            var cmd = @"delete from CardItem where CardId=@p0 and ProductId=@p1";
            _context.Database.ExecuteSqlCommand(cmd,cardId,productId);
        }
        #endregion

        #region Override Method=> Update
        public override void Update(Card entity)
        {
            _context.Cards.Update(entity);
            _context.SaveChanges();
        }
        #endregion
    }
}
