using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagementDecorShin.Models;
using ManagementDecorShin.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ManagementDecorShin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICategoriesRepository categoriesRepository;

        public HomeController(IProductRepository productRepository,
            IWebHostEnvironment webHostEnvironment,
            ICategoriesRepository categoriesRepository)
        {
            this.productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.categoriesRepository = categoriesRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel()
            {
                products = productRepository.Gets(),
                TitleName = "Index"
            };
            ViewBag.Categories = GetCategories();
            return View(indexViewModel);
        }
        public IActionResult Dashboard()
        {
            ViewBag.Categoriess = GetCategories().ToList();
            var indexViewModel = new HomeIndexViewModel()
            {
                products = productRepository.Gets(),
                TitleName = "Index"
            };
            return View(indexViewModel);
        }
        
        public ViewResult Detail(int id)
        {
            var product = productRepository.Gets().ToList();
            var category = categoriesRepository.Gets().ToList();
            var categoryID = productRepository.Get(id).CategoriesCategoryId;
            if (product == null)
            {
                return View("~/Views/Error/ProductNotFound.cshtml");
            }
           
            var detailsViewModel = new HomeDetailViewModel()
            {
                Product = productRepository.Get(id),
                TitleName = "Product Detail",
                CategoryName = (
                                from c in category 
                                where c.CategoryId == categoryID
                                select c.CategoryName).FirstOrDefault()
            };
            return View(detailsViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public List<Category> GetCategories()
        {
            return categoriesRepository.Gets().ToList();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Products(int id)
        {
            var products = (from p in productRepository.Gets() where p.CategoriesCategoryId == id select p).ToList();
            var indexViewModel = new HomeIndexViewModel()
            {
                products =products,
                TitleName = "Product"
            };
            ViewBag.Categories = GetCategories();
            return View(indexViewModel);
        }
    }
}
