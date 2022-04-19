using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvenementsAPI.Models
{
    public class Evenement : BaseEntite
    {
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<CategorieEvenement> EvenementCategories { get; set; }
        public ICollection<Participation> Participations { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string NomOrganisateur { get; set; }
        public int VilleId { get; set; }
        public Ville Ville { get; set; }
        public double Prix { get; set;}
    }
}
