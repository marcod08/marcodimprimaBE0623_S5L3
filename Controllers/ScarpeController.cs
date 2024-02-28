using Microsoft.AspNetCore.Mvc;
using S5L3.Models;

namespace S5L3.Controllers
{
    public class ScarpeController : Controller
    {
        private readonly DatabaseContext _context;

        public ScarpeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var scarpe = _context.Products.ToList();
            return View(scarpe);
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return RedirectToAction("Index", "Scarpe");

            var scarpe = _context.Products.Find(id);
            if (scarpe is null)
                return View("Error");

            return View(scarpe);
        }


        [HttpPost]
        public IActionResult Edit(Products scarpe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Update(scarpe);
                    _context.SaveChanges();
                    return RedirectToAction("Index", new { id = scarpe.Id });
                }
                catch (Exception)
                { 
                    return View("Error");
                }
            }
            return View(scarpe);
        }

        [HttpPost]
        public IActionResult Add(Products scarpe)
        {
            if (ModelState.IsValid)
            {

                _context.Products.Add(scarpe);
                _context.SaveChanges();

                return RedirectToAction("Index", new { id = scarpe.Id });
            }

            return View(scarpe);
        }
    }
}