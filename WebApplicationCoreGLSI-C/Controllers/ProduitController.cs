using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSI_C.Models;
using WebApplicationCoreGLSI_C.Models.ViewModel;

namespace WebApplicationCoreGLSI_C.Controllers
{
    public class ProduitController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProduitController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var p = _context.produits.ToList();
            return View(p);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create( ProduitVM model, IFormFile photo)
        {
            if (photo == null) return Content("Photo not uploaded");

            try
            {

                var path = Path.Combine(webHostEnvironment.
                    WebRootPath, "Images", photo.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                    stream.Close();
                }

               // model.produit.FileImage = photo.FileName;

                //Mapping manuel (automatique-->automapper)

                var produit = new Produit
                {
                    Id = new Guid(),
                    Name = model.produit.Name,

                    FileImage = photo.FileName,

                };
                _context.Add(produit);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}

