#pragma warning disable CS8602
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Web.Controllers
{
    public class CategoryController(ICategoryRepository categoryRepository) : Controller
    {
        private readonly ICategoryRepository categoryRepository = categoryRepository;

        public IActionResult Index()
        {
            List<Category> objCategoryList = [.. categoryRepository.GetAll()];
            return View(objCategoryList);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = categoryRepository.GetFirstOrDefault(category =>
                category.Id == id
            );
            return categoryFromDb is null ? NotFound() : View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(obj);
                categoryRepository.Save();
                TempData["success"] = $"Category {obj.Name} edit successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = categoryRepository.GetFirstOrDefault(category =>
                category.Id == id
            );
            return categoryFromDb is null ? NotFound() : View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = categoryRepository.GetFirstOrDefault(category =>
                category.Id == id
            );

            if (categoryFromDb is null)
            {
                return NotFound();
            }
            categoryRepository.Remove(categoryFromDb);
            categoryRepository.Save();
            TempData["success"] = $"Category {categoryFromDb.Name} deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError(
                    "name",
                    "The Display Order cannot exactly match the Category Name"
                );
            }
            if (ModelState.IsValid)
            {
                categoryRepository.Add(obj);
                categoryRepository.Save();
                TempData["success"] = $"Category {obj.Name} created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
