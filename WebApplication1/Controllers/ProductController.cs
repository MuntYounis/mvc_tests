using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ViewResult Index() {
            var prods = context.Products.ToList();

            return View(prods);
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult Details(int id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        public ViewResult Edit() {
            return View("Edit");
        }


        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);
            if (product is null)
            {
                return RedirectToAction("Index");

            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
