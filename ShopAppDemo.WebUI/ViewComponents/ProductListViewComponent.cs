using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.ViewComponents
{
    public class ProductListViewComponent:ViewComponent
    {
        private IProductService _productService;
        public ProductListViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll().ToList()
            }); 
        }
    }
}
