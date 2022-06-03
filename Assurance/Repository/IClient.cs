using Assurance.Controllers;
using Assurance.Models.EF;
using Assurance.Models.Extend;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public interface IClient
    {
        /// get list of all Client
        List<Client> GetClientsList();

        /// get Client details by client id
        Client GetClientDetailsById(int IdClient);

        ///  add edit Client
        ResponseModel SaveClient(Client ClientModel);
       
        /// delete Client
        ResponseModel DeleteClient(int IdClient);

        List<NbrContratParClient> GetNbrContratParClient(int IdClient);
        List<ListContratByClient> GetContratByClient(int IdClient);
        
    }
}
