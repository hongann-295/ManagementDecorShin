using ManagementDecorShin.Models;
using ManagementDecorShin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICategoriesRepository categoriesRepository;

        public ProductController(IProductRepository productRepository,
            IWebHostEnvironment webHostEnvironment,
            ICategoriesRepository categoriesRepository)
        {
            this.productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Categoriess = GetCategories().ToList();
            var indexViewModel = new HomeIndexViewModel()
            {
                products = productRepository.Gets(),
                TitleName = "Index"
            };
            return View(indexViewModel);
        }
        
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = model.ProductName,
                    Description = model.Description,
                    Price = model.Price,
                    Count = model.Count,
                    CategoriesCategoryId = model.CategoryId

                };
                var fileName = string.Empty;
                if (model.ProductImage != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.ProductImage.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProductImage.CopyTo(fs);
                    }
                }
                product.ProductImage = fileName;
                var newPrd = productRepository.Create(product);
                return RedirectToAction("Index","Product", new { id = newPrd.ProductId });
            }
            return View();
        }

        public ViewResult Edit(int id)
            {
            var product = productRepository.Get(id);
            ViewBag.Categories = categoriesRepository.Gets().ToList();
            var editPrd = new HomeEditViewModel()
            {
                ProductPath = product.ProductImage,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoriesCategoryId,
                Id = product.ProductId
            };
            return View(editPrd);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = model.ProductName,
                    Description = model.Description,
                    Price = model.Price,
                    Count = model.Count,
                    CategoriesCategoryId = model.CategoryId,
                    ProductId = model.Id
                };
                var fileName = string.Empty;
                if (model.ProductImage != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.ProductImage.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProductImage.CopyTo(fs);
                    }
                    product.ProductImage = fileName;
                }
                else
                {
                    product.ProductImage = model.ProductPath;
                }
                var editPrd = productRepository.Edit(product);
                if (editPrd != null)
                {
                    return RedirectToAction("Index","Product", new { id = product.ProductId });
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (productRepository.Delete(id))
            {
                return RedirectToAction("Index","Product");
            }
            return View();
        }
        private List<Category> GetCategories()
        {
            return categoriesRepository.Gets().ToList();
        }
    }
}
