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
    [Authorize]
    public class BrancheController : ControllerBase
    {
        private IBranche _context;
        public BrancheController(IBranche service)
        {
            _context = service;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Branche> GetBranchesList()
        {
            List<Branche> BrancheList;
            try
            {
                BrancheList = _context.GetBranchesList().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return BrancheList;
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetBrancheById([Required]int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var Branche = _context.GetBrancheDetailsById(id);
                if (Branche == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Branche Not Found";
                    return Ok(model);
                }
                return Ok(Branche);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex;
                return Ok(model);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveBranche([Required(ErrorMessage = "The Libele field is required")] string Libele
                                        , [Required(ErrorMessage = "The Code field is required")] string Code)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Branche BrancheModel = new Branche();
                BrancheModel.LibeleBranche = Libele;
                BrancheModel.CodeBranche = Code;
                model = _context.SaveBranche(BrancheModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex;
                return Ok(model);
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public IActionResult DeleteBranche([Required]int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                model = _context.DeleteBranche(id);
                return Ok(model);
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
