#pragma warning disable CS8602
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            List<Product> objProductList = [.. _unitOfWork.Product.GetAll()];
            return View(objProductList);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(product =>
                product.Id == id
            );
            return productFromDb is null ? NotFound() : View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = $"Product {obj.Title} edit successfully";
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
            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(product =>
                product.Id == id
            );
            return productFromDb is null ? NotFound() : View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(product =>
                product.Id == id
            );

            if (productFromDb is null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = $"Product {productFromDb.Title} deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork
                .Category.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = $"Product {obj.Title} created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
