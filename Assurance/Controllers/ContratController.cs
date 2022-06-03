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
    public class ContratController : ControllerBase
    {
        private readonly IContrat _context;
        public ContratController(IContrat service)
        {
            _context = service;
        }
       

        [HttpGet]
        [Route("[action]")]
        public List<Contrat> GetContratsList()
        {
            List<Contrat> ContratList;
            try
            {
                ContratList = _context.GetContratsList().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return ContratList;
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetContratById([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var Contrat = _context.GetContratDetailsById(id);
                if (Contrat == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Contrat not found";
                    return Ok(model);
                }
                return Ok(Contrat);
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
        public IActionResult SaveContrat([Required(ErrorMessage = "The Number of Contrat is required")]
                                            int Number,
                                            [Required(ErrorMessage = "The start date is required")]
                                            [DataType(DataType.Date)]
                                            DateTime DateAffectation,
                                            [Required(ErrorMessage = "The End date is required")]
                                            [DataType(DataType.Date)]
                                            DateTime DateEcheance,
                                            [Required(ErrorMessage = "The creation date is required")]
                                            [DataType(DataType.Date)]
                                            DateTime DateCreation,
                                            [Required]
                                            int IdBranche,
                                            [Required]
                                            int IdClient)
        {
            ResponseModel model = new ResponseModel();
            Contrat ContratModel = new Contrat();
            ContratModel.NContrat = Number;
            ContratModel.DateAffect = DateAffectation;
            ContratModel.DateCreation = DateCreation;
            ContratModel.DateEcheance = DateEcheance;
            try
            {
                model = _context.SaveContrat(ContratModel, IdClient,IdBranche);
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
        public IActionResult DeleteContrat([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                model = _context.DeleteContrat(id);
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
