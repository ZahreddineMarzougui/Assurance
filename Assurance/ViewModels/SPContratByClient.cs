using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class SPContratByClient
    {
        public int ContratId { get; set; }
        public int NumContrat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateAffectation { get; set; }
        public DateTime DateEcheance { get; set; }
        public string Branche { get; set; }
    }
}
