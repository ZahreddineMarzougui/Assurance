using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class Contrat
    {
        [Key, Required]
        public int IdContrat { get; set; }
        [Required(ErrorMessage = "The Number of Contrat is required")]
        public int NContrat { get; set; }
        [Required(ErrorMessage = "The start date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime DateAffect { get; set; }

        [Required(ErrorMessage = "The End date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime DateEcheance { get; set; }

        [Required(ErrorMessage = "The creation date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime DateCreation { get; set; }
        
        public Branche Branche { get; set; }
        
        public Client Client { get; set; }
    }
}
