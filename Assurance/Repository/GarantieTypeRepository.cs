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
    public class GarantieTypeRepository : IGarantieType
    {
        private readonly AssuranceContext _context;
        public GarantieTypeRepository(AssuranceContext context)
        {
            _context = context;
        }
        public List<TypeGarantie> GetGarantieTypeList()
        {
            List<TypeGarantie> brList;
            try
            {
                brList = _context.Set<TypeGarantie>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return brList;
        }
        public TypeGarantie GetGarantieTypeDetailsById(int IdGarantieType)
        {
            TypeGarantie br;
            try
            {
                br = _context.Find<TypeGarantie>(IdGarantieType);
                return br;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
