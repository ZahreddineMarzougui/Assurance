using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.Extend
{
    [NotMapped]
    public class ListContratByClient
    {
        public int IdContrat { get; set; }
        public int NumContrat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateAffectation { get; set; }
        public DateTime DateEcheance { get; set; }
        public string Branche { get; set; }

    }
}
