namespace WebApplicationCoreGLSI_C.Models
{
    public class SousCategorie
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public Guid CategorieId { get; set; }
        public Categorie? categorie { get; set; }
        public IList<Produit>? produits { get; set; }
    }
}
