using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class Garantie
    {
        public Garantie()
        {
            this.Branche = new HashSet<Branche>();
        }
        [Key, Required]
        public int IdGarantie { get; set; }
        [Required(ErrorMessage = "The Libele field is required")]
        public string LibeleGarantie { get; set; }

        [Required(ErrorMessage = "The Code field is required")]
        public string CodeGarantie { get; set; }

        [Required]
        public TypeGarantie TypeGarantie { get; set; }
        [Required]
        public virtual ICollection<Branche> Branche { get; set; }

    }
}
