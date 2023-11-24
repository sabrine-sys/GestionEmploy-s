using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace WebApplicationCoreGLSI_C.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> 
            options):base(options)
        {

        }
        public DbSet<Produit> produits { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<SousCategorie> sscategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //fluent API
            // modelbuilder.Entity<Categorie>().ToTable("DBOCateg");
            modelbuilder.Entity<Categorie>()
                .Property(c => c.Name)
                .HasColumnType("varchar(20)")
                .HasDefaultValue("ABC");
            modelbuilder.Entity<SousCategorie>()
                .Property(c => c.Name)
                .HasColumnName("SousCatName")
                .HasMaxLength(255);
            //modelbuilder.Entity<Categorie>()
            //    .HasData(
            //    new Categorie()
            //    {
            //        Id = new Guid("b1f663bd-5435-4820-8c65-7787965a4a89"),
            //        Name = "Cat From APIFluent",
            //    });
            var CatJson = System.IO.File
                    .ReadAllText("Categorie.Json");
            List<Categorie> categories = System.Text.Json.
               JsonSerializer.Deserialize<List<Categorie>>(CatJson);
            //Seed to categorie
            foreach (Categorie c in categories)
                modelbuilder.Entity<Categorie>()
                .HasData(c);
        }

    }
}
