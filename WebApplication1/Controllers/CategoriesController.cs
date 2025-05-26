using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ViewResult Index()
        {
            var cats = context.Categories.ToList();

            return View(cats);
        }

        public IActionResult Details(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();


        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(c=>c.Id == id);
            if (category is null)
            {
                return RedirectToAction("Index");

            }
            context.Categories.Remove(category);
            context.SaveChanges() ;
            return RedirectToAction("Index");
        }

    }
}
