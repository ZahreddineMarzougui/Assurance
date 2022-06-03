using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public interface IBranche
    {
        /// get list of all Branche
        List<Branche> GetBranchesList();

        /// get Branche details by Branche id
        Branche GetBrancheDetailsById(int IdBranche);

        ///  add edit Branche
        ResponseModel SaveBranche(Branche BrancheModel);

        /// delete Branche
        ResponseModel DeleteBranche(int IdBranche);
    }
}
