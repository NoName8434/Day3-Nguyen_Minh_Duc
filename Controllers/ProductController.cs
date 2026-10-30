using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay3.Models;

namespace Ngay3.Controllers
{
    public class ProductController : Controller
    {
        //gia lap csdl

        private static List<Models.Product> _products = new List<Models.Product>()
        {
            new Models.Product() { Id = 1, Name = "Product 1", Price = 10.99m, Description = "Description for Product 1", CategoryId = 1 },
            new Models.Product() { Id = 2, Name = "Product 2", Price = 19.99m, Description = "Description for Product 2", CategoryId = 2 },
            new Models.Product() { Id = 3, Name = "Product 3", Price = 5.99m, Description = "Description for Product 3", CategoryId = 3 }
        };
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                product.Id = id;
                _products.Add(product);

            }
            return View();
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) 
            {
              return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
