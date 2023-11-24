using Azure.Messaging;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApplicationCoreGLSI_C.Models
{
    public class Categorie
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string Name { get; set; } 
    }
}
