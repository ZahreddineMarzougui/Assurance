using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public interface IGarantie
    {
        /// get list of all Garantie
        List<Garantie> GetGarantiesList();

        /// get Garantie details by Garantie id
        Garantie GetGarantieDetailsById(int IdGarantie);

        ///  add edit Garantie
        ResponseModel SaveGarantie(Garantie GarantieModel);

        /// delete Garantie
        ResponseModel DeleteGarantie(int IdGarantie);
        TypeGarantie GetGarantieTypeById(int IdType);
    }
}
