using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;

namespace ShopAppDemo.WebUI.Controllers
{
    public class CategoryProductController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryProductController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Remove(int productId, int categoryId)
        {
            _categoryService.RemoveFromCategoryProduct(productId, categoryId);
            return Redirect("/Category/Edit/"+categoryId);
        }
    }
}