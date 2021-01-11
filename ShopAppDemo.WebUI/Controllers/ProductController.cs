using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.Entities;
using ShopAppDemo.WebUI.Models;
using ShopAppDemo.WebUI.ViewModels;

namespace ShopAppDemo.WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string category, int page = 1)
        {
            const int pageSize = 3;
            return View(new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentCategory = category,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetProductsByCategoryCount(category)
                }
            });
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsViewModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(x => x.Category).ToList()
            });
        }

        #region List
        [Authorize(Roles = "admin")]
        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll().ToList()
            });
        }
        #endregion

        #region Add
        [Authorize(Roles ="admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(ProductModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    if (model != null)
                    {
                        Product entity = new Product()
                        {
                            Name = model.Name,
                            Price = model.Price,
                            Description = model.Description,
                            Image = file.FileName
                        };

                        if (_productService.Create(entity))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ViewBag.ErrorMessages = _productService.ErrorMessage;
            return View(model);
        }
        #endregion

        #region Edit
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = _categoryService.GetAll();
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);

            var model = new ProductModel()
            {

                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Image = entity.Image,
                Description = entity.Description,
                SelectedCategories = entity.ProductCategories.Select(x => x.Category).ToList(),
                Categories = _categoryService.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(ProductModel model, int[] categoriesID, IFormFile file)
        {
            var entity = _productService.GetById(model.Id);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    if (entity != null)
                    {
                        entity.Name = model.Name;
                        entity.Image = file.FileName;
                        entity.Price = model.Price;
                        entity.Description = model.Description;

                        _productService.Update(entity, categoriesID);
                        return RedirectToAction("List");
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Delete
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var entity = _productService.GetById(id);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}