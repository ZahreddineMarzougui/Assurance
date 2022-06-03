using Assurance.Models.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models
{
    public static class SeedDataAssurance
    {
        public static void seed (this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeGarantie>().HasData(
                new TypeGarantie() {IdTypeGa = 1 ,LibeleTypeGa = "Obligatoire", CodeTypeGa = "OBLIGATOIR" },
                new TypeGarantie() {IdTypeGa = 2, LibeleTypeGa = "Facultatif", CodeTypeGa = "FACULTATIF" }
                );
        }
    }
}
