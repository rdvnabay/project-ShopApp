using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Models;


namespace ShopAppDemo.WebUI.Controllers
{

    public class CardController : Controller
    {
        #region Variables
        private ICardService _cardService;
        private UserManager<AppUser> _userManager;
        #endregion

        #region Constructor
        public CardController(ICardService cardService, UserManager<AppUser> userManager )
        {
            _cardService = cardService;
            _userManager = userManager;
        }
        #endregion

        #region Action=> Index
        public IActionResult Index()
        {
            var card = _cardService.GetCardByUserId(_userManager.GetUserId(User));
            return View(new CardModel()
            {
                Id = card.Id,
                CardItems = card.CardItems.Select(x => new CardItemModel()
                {
                    Id=x.Id,
                    ProductId=x.Product.Id,
                    Name=x.Product.Name,
                    Price=x.Product.Price,
                    Image=x.Product.Image,
                    Quantity=x.Quantity
                   
                }).ToList()
            });  
        }
        #endregion

        #region Action=> AddToCard
        [HttpPost]
        public IActionResult AddToCard(int productId, int quantity)
        {
            _cardService.AddToCard(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }
        #endregion

        #region Action=> RemoveFromCard
        [HttpPost]
        public IActionResult RemoveFromCard(int productId)
        {
            _cardService.RemoveFromCard(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }
        #endregion
    }
}