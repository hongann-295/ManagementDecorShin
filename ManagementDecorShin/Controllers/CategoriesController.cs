
using ManagementDecorShin.Models;
using ManagementDecorShin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Controllers
{

    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }
        public IActionResult Index()
        {
            var categories = categoriesRepository.Gets();
            var model = new List<Category>();
            model = categories.Select(r => new Category()
            {
                CategoryId = r.CategoryId,
                CategoryName = r.CategoryName
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = categoriesRepository.Create(new Category()
                {
                    CategoryName = model.CategoryName
                });
                if (result != null)
                {
                    return RedirectToAction("index", "categories");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = categoriesRepository.Get(id);
            ViewBag.Categories = categoriesRepository.Gets().ToList();
            var editCategory = new CategoryEditViewModel()
            {
                CategoryName = categories.CategoryName,
                CategoryId = categories.CategoryId
            };
            return View(editCategory);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categories = new Category()
                {
                    CategoryName = model.CategoryName,
                    CategoryId = model.CategoryId
                };

                var editCategory = categoriesRepository.Edit(categories);
                if (editCategory != null)
                {
                    return RedirectToAction("Index", "Categories", new { id = categories.CategoryId });
                }
            }
            return View();
        }
      
        public IActionResult Delete(int id)
        {
            if (categoriesRepository.Delete(id))
            {
                return RedirectToAction("Index", "Categories");
            }
            return View();
        }


    }
}
