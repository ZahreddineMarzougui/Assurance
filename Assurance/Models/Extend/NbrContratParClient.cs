using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.Extend
{
    [NotMapped]
    public class NbrContratParClient
    {
        public string Date { get; set; }
        public int nbrContrat { get; set; }

    }
}
