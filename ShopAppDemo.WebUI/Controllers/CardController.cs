using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Models;
using System.Linq;


namespace ShopAppDemo.WebUI.Controllers
{
    public class CardController : Controller
    {
        private ICardService _cardService;
        private UserManager<AppUser> _userManager;

        public CardController(ICardService cardService, UserManager<AppUser> userManager )
        {
            _cardService = cardService;
            _userManager = userManager;
        }

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

        [HttpPost]
        public IActionResult AddToCard(int productId, int quantity)
        {
            _cardService.AddToCard(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCard(int productId)
        {
            _cardService.RemoveFromCard(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }
    }
}