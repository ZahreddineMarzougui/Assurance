using Assurance.Models;
using Assurance.Models.EF;
using Assurance.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Repository
{
    public class BrancheRepository : IBranche
    {
        private readonly AssuranceContext _context;
        public BrancheRepository(AssuranceContext context)
        {
            _context = context;
        }
        public ResponseModel DeleteBranche(int IdBranche)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Branche _temp = GetBrancheDetailsById(IdBranche);
                if (_temp != null)
                {
                    _context.Remove<Branche>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Branche Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Branche Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public Branche GetBrancheDetailsById(int IdBranche)
        {
            Branche br;
            try
            {
                br = _context.Find<Branche>(IdBranche);
                return br;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Branche> GetBranchesList()
        {
            List<Branche> brList;
            try
            {
                brList = _context.Set<Branche>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return brList;
        }

        public ResponseModel SaveBranche(Branche BrancheModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Branche _temp = GetBrancheDetailsById(BrancheModel.IdBranche);
                if (_temp != null)
                {
                    _temp.LibeleBranche = BrancheModel.LibeleBranche;
                    _temp.CodeBranche = BrancheModel.CodeBranche;
                    _context.Update<Branche>(_temp);
                    model.Message = "Branche Update Successfully";
                }
                else
                {
                    _context.Add<Branche>(BrancheModel);
                    model.Message = "Branche Inserted Successfully";
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
