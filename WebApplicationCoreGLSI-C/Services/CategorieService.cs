using WebApplicationCoreGLSI_C.Models;
using WebApplicationCoreGLSI_C.ServicesContracts;

namespace WebApplicationCoreGLSI_C.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _appDbContext;
        public CategorieService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Categorie> GetAll()
        {
            return _appDbContext.categories.ToList();
        }
    }
}
