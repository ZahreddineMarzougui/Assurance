using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.Extend
{
    [NotMapped]
    public class ListGarantieByContrat
    {
        public string Libele { get; set; }
        public string Code { get; set; }

    }
}
