using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSI_C.Models;

namespace WebApplicationCoreGLSI_C.Controllers
{
    public class SousCategorieController : Controller
    {
        private readonly AppDbContext appDbContext;
        public SousCategorieController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var c = await appDbContext.sscategories.Include(c=>c.categorie).ToListAsync();
            return View(c);
        }
        public IActionResult Create()
        {
            var c = appDbContext.categories.ToList();
            ViewBag.Categories = c.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SousCategorie sousCategorie)
        {
            if(!ModelState.IsValid)
            {
                var c = appDbContext.categories.ToList();
                ViewBag.Categories = c.Select(c =>
                    new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                    });
                return View();
            }
            sousCategorie.Id = Guid.NewGuid();
            appDbContext.sscategories.Add(sousCategorie);
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
       
    }
}
