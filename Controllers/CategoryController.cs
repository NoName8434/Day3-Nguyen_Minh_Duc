using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay3.Models;
namespace Ngay3.Controllers
{
    public class CategoryController : Controller
    {   // gia lap csdl
        private static List<Category> _categories = new List<Models.Category>()
        {
            new Category() { Id = 1, Name = "Category 1" },
            new Category() { Id = 2, Name = "Category 2" },
            new Category() { Id = 3, Name = "Category 3" }
        };
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
  
        public ActionResult Create()
        {
            return View();
           
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //them catagory vao danh sach
                int newId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
                category.Id = newId;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var exitstingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (exitstingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                exitstingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
           var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
