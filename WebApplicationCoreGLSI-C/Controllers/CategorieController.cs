using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationCoreGLSI_C.Models;

namespace WebApplicationCoreGLSI_C.Controllers
{
    public class CategorieController : Controller
    {
        private readonly AppDbContext _db;
        public CategorieController(AppDbContext _db)
        {
            this._db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.categories.ToListAsync());
        }
        public IActionResult DownLoadFile()
        {
            byte[] bytes = System.IO
                .File.ReadAllBytes(@"C:\Users\TEK-UP\Desktop\Document.pdf");
            return File(bytes, "application/pdf");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie categorie)
        {
            _db.categories.Add(categorie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if(id== null) return NotFound();
            var categorie = _db.categories.FirstOrDefault(c => c.Id==id);
            return View(categorie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie cat)
        {
            _db.categories.Update(cat);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var c = _db.categories.Find(id);
            return View(c);
            //_db.categories.Remove(c);
            //_db.SaveChanges();
            //return RedirectToAction("Index");
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid? id)
        {
            var c = _db.categories.Find(id);
            _db.categories.Remove(c);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
