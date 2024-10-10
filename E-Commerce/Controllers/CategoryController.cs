using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var Category = Context.Categorys.ToList();
            return View(Category);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AddToDb(Category category)
        {
            Context.Categorys.Add(category);
            Context.SaveChanges();
            return  RedirectToAction("Index");

        }
        public IActionResult Edit(int CategoryId)
        {
            var category = Context.Categorys.Find(CategoryId);
            return View(category);
        }
        public IActionResult EditToDb(Category category)
        {
            Context.Categorys.Update(category);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(Category category)
        {
            Context.Categorys.Remove(category);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
