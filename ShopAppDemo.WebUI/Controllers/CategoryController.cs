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
    public class CategoryController : Controller
    {

        #region Fields
        private ICategoryService _categoryService;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        //Actions
        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region List
        [Authorize(Roles = "admin")]
        public IActionResult List()
        {
            return View(new CategoryListModel() { 
            Categories= _categoryService.GetAll().ToList()
            });
        }
        #endregion

        #region Add
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (model!=null)
                {
                    var entity = new Category()
                    {
                        Id = model.Id,
                        Name = model.Name
                    };
                    _categoryService.Create(entity);
                    return RedirectToAction("List");
                }
            }
            return View();
        }
        #endregion

        #region Edit
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            var entity = _categoryService.GetByIdWithProducts((int)id);
            if (id!=null)
            {
                return View(new CategoryModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Products = entity.ProductCategories.Select(x => x.Product).ToList()
                });
            }
            return NotFound();
           
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Category model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (ModelState.IsValid)
            {
                if (model!=null)
                {
                    entity.Id = model.Id;
                    entity.Name = model.Name;
                    _categoryService.Update(entity);
                    return RedirectToAction("List");
                } 
            }
            return View(model);
        }
        #endregion

        #region Delete
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetById((int)id);
            _categoryService.Delete(entity);
            return RedirectToAction("List");
        }
        #endregion
    }
}