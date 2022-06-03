using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class Branche
    {
        public Branche()
        {
            this.Garantie = new HashSet<Garantie>();
        }
        [Key,Required]
        public int IdBranche { get; set; }
        [Required(ErrorMessage = "The Libele field is required")]
        public string LibeleBranche { get; set; }

        [Required(ErrorMessage = "The Code field is required")]
        public string CodeBranche { get; set; }

        [Required]
        public virtual ICollection<Garantie> Garantie { get; set; }
        [Required]
        public ICollection<Contrat> Contrat { get; set; }

    }
}
