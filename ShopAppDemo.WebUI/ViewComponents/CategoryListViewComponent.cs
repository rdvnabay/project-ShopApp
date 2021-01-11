using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll().ToList()
            }); 
        }
    }
}
