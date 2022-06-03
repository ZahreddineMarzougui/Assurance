using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public interface IContrat
    {
        /// get list of all Contrat
        List<Contrat> GetContratsList();

        /// get Contrat details by Contrat id
        Contrat GetContratDetailsById(int IdContrat);

        ///  add edit Contrat
        ResponseModel SaveContrat(Contrat ContratModel,int IdClient,int IdBranche);

        /// delete Contrat
        ResponseModel DeleteContrat(int IdContrat);
    }
}
