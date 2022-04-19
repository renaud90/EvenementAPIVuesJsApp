using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvenementsAPI.Models
{
    public class Participation : BaseEntite
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Courriel invalide")]
        public string Courriel { get; set; }
        [Required]
        public int NbPlaces { get; set; }
        public bool IsValid { get; set; } = false;
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }
    }
}
