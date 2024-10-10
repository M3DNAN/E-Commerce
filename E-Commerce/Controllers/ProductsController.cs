using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class ProductsController : Controller
    {

        ApplicationDbContext Context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = Context.Products.Include(E=>E.Category) .ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = Context.Categorys.ToList();
            return View(categories);
        }
        [HttpPost]
        public IActionResult AddToDb(Product product , IFormFile PhotoUrl)
        {
            if (PhotoUrl.Length > 0)
            {
                var fileName = PhotoUrl.FileName;
                var filePath=  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\images", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    PhotoUrl.CopyTo(stream);
                }
                product.PhotoUrl = fileName;
            }
            Context.Products.Add(product);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int productId)
        {
            var product = Context.Products.Find(productId);
            var categories = Context.Categorys.ToList();
            ViewData["categories"] = categories;
            return View(product);
        }
        public IActionResult EditToDb(Product product)
        {
            Context.Products.Update(product);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(Product product)
        {
            Context.Products.Remove(product);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
