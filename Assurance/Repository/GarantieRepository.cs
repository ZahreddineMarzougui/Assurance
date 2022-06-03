using Assurance.Models;
using Assurance.Models.EF;
using Assurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public class GarantieRepository : IGarantie
    {
        private AssuranceContext _context;
        public GarantieRepository(AssuranceContext context)
        {
            _context = context;
        }
        public ResponseModel DeleteGarantie(int IdGarantie)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Garantie _temp = GetGarantieDetailsById(IdGarantie);
                if (_temp != null)
                {
                    _context.Remove<Garantie>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Garantie Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Garantie Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public Garantie GetGarantieDetailsById(int IdGarantie)
        {
            Garantie grt;
            try
            {
                grt = _context.Find<Garantie>(IdGarantie);
                return grt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TypeGarantie GetGarantieTypeById(int IdType)
        {
            TypeGarantie tgrt;
            try
            {
                tgrt = _context.Find<TypeGarantie>(IdType);
                return tgrt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Garantie> GetGarantiesList()
        {
            List<Garantie> grtList;
            try
            {
                grtList = _context.Set<Garantie>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return grtList;
        }

        public ResponseModel SaveGarantie(Garantie GarantieModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Garantie _temp = GetGarantieDetailsById(GarantieModel.IdGarantie);
                if (_temp != null)
                {
                    _temp.CodeGarantie = GarantieModel.CodeGarantie;
                    _temp.LibeleGarantie = GarantieModel.LibeleGarantie;
                    _temp.TypeGarantie.IdTypeGa = GarantieModel.TypeGarantie.IdTypeGa;
                    _context.Update<Garantie>(_temp);
                    model.Message = "Garantie Update Successfully";
                }
                else
                {
                    _context.Add<Garantie>(GarantieModel);
                    model.Message = "Garantie Inserted Successfully";
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
    }
}
