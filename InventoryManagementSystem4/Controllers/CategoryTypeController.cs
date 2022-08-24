using InventoryManagementSystem4.Data;
using InventoryManagementSystem4.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem4.Controllers
{
    //.HTACCESS DOSYASI YÖREVİNDE ÇALIŞIYOR
    public class CategoryTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult IndexType()
        {
            IEnumerable<CategoryType> objCategoryList = _db.CategoryType;
            return View(objCategoryList);
        }
        //GET
        public IActionResult CreateType()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateType(CategoryType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryType.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory created successfully";
                return RedirectToAction("IndexType");
            }
            return View(obj);
        }
        //GET
        public IActionResult EditType(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.CategoryType.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditType(CategoryType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryType.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory updated successfully";
                return RedirectToAction("IndexType");
            }
            return View(obj);
        }
        //GET
        public IActionResult DeleteType(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.CategoryType.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("DeleteType")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.CategoryType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.CategoryType.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Catagory deleted successfully";
            return RedirectToAction("IndexType");

        }
    }
}
