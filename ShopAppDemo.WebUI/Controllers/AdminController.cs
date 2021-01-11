using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.Entities;
using ShopAppDemo.WebUI.Models;

namespace ShopAppDemo.WebUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
      
    }
}