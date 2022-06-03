using Assurance.Controllers;
using Assurance.Models;
using Assurance.Models.EF;
using Assurance.Models.Extend;
using Assurance.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public class ClientRepository : IClient
    {
        private readonly AssuranceContext _context;
        public ClientRepository(AssuranceContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteClient(int IdClient)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Client _temp = GetClientDetailsById(IdClient);

                if (_temp != null)
                {
                    _context.Remove<Client>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Client Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Client Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public Client GetClientDetailsById(int IdClient)
        {
            Client cli;
            try
            {
                cli = _context.Find<Client>(IdClient);
                return cli;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Client> GetClientsList()
        {
            List<Client> cltList;
            try
            {
                cltList = _context.Set<Client>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return cltList;
        }

        

        public ResponseModel SaveClient(Client ClientModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Client _temp = GetClientDetailsById(ClientModel.IdClient);
                if (_temp != null)
                {
                    _temp.FirstName = ClientModel.FirstName;
                    _temp.LastName = ClientModel.LastName;
                    _temp.CIN = ClientModel.CIN;
                    _temp.Phone = ClientModel.Phone;
                    _temp.Email = ClientModel.Email;
                    _temp.Address = ClientModel.Address;
                    _temp.Country = ClientModel.Country;
                    _temp.CodePostal = ClientModel.CodePostal;
                    _context.Update<Client>(_temp);
                    model.Message = "Client Update Successfully";
                }
                else
                {
                    _context.Add<Client>(ClientModel);
                    model.Message = "Client Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }



        public List<NbrContratParClient> GetNbrContratParClient(int IdClient)
        {
            var ClientId = new SqlParameter("@IdClient", IdClient);

            List<NbrContratParClient> lstClient = _context
                                .NbrContratParClient
                                    .FromSqlRaw("Exec GetNbrContratParClient @IdClient", ClientId).ToList();

            return lstClient;
        }

        public List<ListContratByClient> GetContratByClient(int IdClient)
        {
            var ClientId = new SqlParameter("@IdClient", IdClient);

            List<ListContratByClient> ListContrat = _context
                                .ListContratByClient
                                    .FromSqlRaw("Exec GetContratByClient @IdClient", ClientId).ToList();

            return ListContrat;
        }
        
    }
}
