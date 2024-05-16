using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            List<Category> objCategoryList = [.. _db.Categories];
            return View(objCategoryList);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            return categoryFromDb is null ? NotFound() : View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _ = _db.Categories.Update(obj);
                _ = _db.SaveChanges();
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
            Category? categoryFromDb = _db.Categories.Find(id);
            return categoryFromDb is null ? NotFound() : View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb is null)
            {
                return NotFound();
            }
            _ = _db.Categories.Remove(categoryFromDb);
            _ = _db.SaveChanges();
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
                _ = _db.Categories.Add(obj);
                _ = _db.SaveChanges();
                TempData["success"] = $"Category {obj.Name} created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
