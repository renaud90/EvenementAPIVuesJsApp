using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvenementsAPI.Models
{
    public class Categorie : BaseEntite
    {
        [Required]
        public string Nom { get; set; }
        public ICollection<CategorieEvenement> EvenementCategories { get; set; }
    }
}
