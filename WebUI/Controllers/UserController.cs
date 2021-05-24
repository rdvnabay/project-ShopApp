using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Models.Order;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppDemo.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IOrderService _orderService;
        private UserManager<AppUser> _userManager;
        public UserController(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult MyOrders()
        {
            var orders = _orderService.GetAllFilter(x => x.UserId == _userManager.GetUserId(User)).Data;
            var orderListModel = new List<OrderListModel>();
            OrderListModel orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListModel();
                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.OrderNote = order.OrderNote;
                orderModel.Phone = order.Phone;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Email = order.Email;
                orderModel.Address = order.Address;
                orderModel.City = order.City;

                orderModel.OrderItems = order.OrderItems.Select(i => new OrderItemModel()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.Name,
                    Price = (decimal)i.Price,
                    Quantity = i.Quantity,
                    Image = i.Product.Image
                }).ToList();

                orderListModel.Add(orderModel);
            }

            return View(orderListModel);
        }
    }
}
