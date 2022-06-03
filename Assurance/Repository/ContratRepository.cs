using Assurance.Models;
using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public class ContratRepository : IContrat
    {
        private readonly AssuranceContext _context;
        public ContratRepository(AssuranceContext context)
        {
            _context = context;
        }
        
        public ResponseModel DeleteContrat(int IdContrat)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Contrat _temp = GetContratDetailsById(IdContrat);
                if (_temp != null)
                {
                    _context.Remove<Contrat>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Contrat Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Contrat Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public Contrat GetContratDetailsById(int IdContrat)
        {
            Contrat crt;
            try
            {
                crt = _context.Find<Contrat>(IdContrat);
                return crt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contrat> GetContratsList()
        {
            List<Contrat> crtList;
            try
            {
                crtList = _context.Set<Contrat>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return crtList;
        }

        public ResponseModel SaveContrat(Contrat ContratModel, int IdClient, int IdBranche)
        {
            ResponseModel model = new ResponseModel();
            //Check client and Branche
            Client clientModel = _context.Find<Client>(IdClient);
            Branche BrancheModel = _context.Find<Branche>(IdBranche);
            if(clientModel == null || BrancheModel == null)
            {
                if (clientModel == null) {model.Message = "Client Id incorrect";}
                if (BrancheModel == null) { model.Message = "Branche Id incorrect";}
                model.IsSuccess = false;
                return model;
            }
            else
            {
                ContratModel.Branche = BrancheModel;
                ContratModel.Client = clientModel;
            }
            
            try
            {
                Contrat _temp = GetContratDetailsById(ContratModel.IdContrat);
                if (_temp != null)
                {
                    _temp.NContrat = ContratModel.NContrat;
                    _temp.DateAffect = ContratModel.DateAffect;
                    _temp.DateEcheance = ContratModel.DateEcheance;
                    _temp.DateCreation = ContratModel.DateCreation;
                    _temp.Branche.IdBranche = ContratModel.Branche.IdBranche;
                    _temp.Client.IdClient = ContratModel.Client.IdClient;
                    _context.Update<Contrat>(_temp);
                    model.Message = "Contrat Update Successfully";
                }
                else
                {
                    _context.Add<Contrat>(ContratModel);
                    model.Message = "Contrat Inserted Successfully";
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


        //public SPContratByClient SPContratByClient(int IdClient)
        //{
        //    string StoredProc = "exec SPR_GetContratByClient " +
        //    "@IdClient = " + IdClient + "'";
        //    var x= _contex.FromS(StoredProc);
        //}
    }
}
