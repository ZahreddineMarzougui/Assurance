using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public interface IGarantieType
    {
        /// get list of all GarantieType
        List<TypeGarantie> GetGarantieTypeList();

        /// get GarantieType details by GarantieType id
        TypeGarantie GetGarantieTypeDetailsById(int IdGarantieType);

    }
}
