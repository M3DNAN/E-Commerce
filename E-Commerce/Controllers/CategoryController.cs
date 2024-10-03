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
    }
}
