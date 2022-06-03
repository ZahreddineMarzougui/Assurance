using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class TypeGarantie
    {
        [Key, Required]
        public int IdTypeGa { get; set; }
        [Required(ErrorMessage = "The Libele field is required")]
        public string LibeleTypeGa { get; set; }

        [Required(ErrorMessage = "The Code field is required")]
        public string CodeTypeGa { get; set; }

        
    }
}
