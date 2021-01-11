using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IyzipayCore;
using IyzipayCore.Model;
using IyzipayCore.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.Entities;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Models;
using ShopAppDemo.WebUI.Models.Order;

namespace ShopAppDemo.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        #region Fields
        private UserManager<AppUser> _userManager;
        private ICardService _cardService;
        private IOrderService _orderService;
        #endregion

        #region Constructor
        public OrderController(
            UserManager<AppUser> userManager, 
            ICardService cardService, 
            IOrderService orderService)
        {
            _userManager = userManager;
            _cardService = cardService;
            _orderService = orderService;
        }
        #endregion


        //Actions
        #region Action=> Checkout
        public IActionResult Checkout()
        {
            var cart = _cardService.GetCardByUserId(_userManager.GetUserId(User));

            var orderModel = new OrderModel();

            orderModel.CardModel = new CardModel()
            {
                Id = cart.Id,
                CardItems = cart.CardItems.Select(i => new CardItemModel()
                {
                    Id = i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    Image = i.Product.Image,
                    Quantity = i.Quantity
                }).ToList()
            };

            return View(orderModel);
        }

        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cardService.GetCardByUserId(userId);

                model.CardModel = new CardModel()
                {
                    Id = cart.Id,
                    CardItems = cart.CardItems.Select(i => new CardItemModel()
                    {
                        Id = i.Id,
                        ProductId = i.Product.Id,
                        Name = i.Product.Name,
                        Price = (double)i.Product.Price,
                        Image = i.Product.Image,
                        Quantity = i.Quantity
                    }).ToList()
                };

                var payment = PaymentProcess(model);

                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userId);
                    //ClearCard(cart.Id.ToString());
                    return RedirectToAction("MyOrders","User");
                }
            }

            return View(model);
        }
        #endregion

        #region Method=> SaveOrder
        private void SaveOrder(OrderModel model, Payment payment, string userId)
        {
            var order = new Order();

            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.OrderState = EnumOrderState.Completed;
            order.PaymentTypes = EnumPaymentTypes.CreditCart;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.UserId = userId;

            foreach (var item in model.CardModel.CardItems)
            {
                var orderitem = new OrderItem()
                {
                    Price = (double)item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems.Add(orderitem);
            }
            _orderService.CreateOrder(order);
        }
        #endregion

        #region Method=> ClearCard
        private void ClearCard(string cartId)
        {
            //_cardService.ClearCard(cartId);
        }
        #endregion

        #region Method=> PaymentProcess
        private Payment PaymentProcess(OrderModel model)
        {

            Options options = new Options();
            options.ApiKey = "sandbox-WElywOX7zBkXlvcNMMTRpV3vRNIuOiFN";
            options.SecretKey = "sandbox-16y7zM9UHQ5u4dWMGWue0vU0lunyBIPy";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = "1";
            request.PaidPrice = "1.2";
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            //Payment payment = Payment.Create(request, options);
            return Payment.Create(request, options);

        }
        #endregion



    }
}