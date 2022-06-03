using Assurance.Models.EF;
using Assurance.Repository;
using Assurance.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GarantieTypeController : ControllerBase
    {
        private readonly IGarantieType _context;
        public GarantieTypeController(IGarantieType service)
        {
            _context = service;
        }

        [HttpGet]
        [Route("[action]")]
        public List<TypeGarantie> GetGarantieTypeList()
        {
            List<TypeGarantie> TypeGarantieList;
            try
            {
                TypeGarantieList = _context.GetGarantieTypeList().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return TypeGarantieList;
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetGarantieTypeDetailsById([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var TypeGarantie = _context.GetGarantieTypeDetailsById(id);
                if (TypeGarantie == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Branche Not Found";
                    return Ok(model);
                }
                return Ok(TypeGarantie);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex;
                return Ok(model);
            }
        }

    }
}
