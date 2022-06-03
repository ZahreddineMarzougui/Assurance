using Assurance.Models.EF;
using Assurance.Models.Extend;
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
    public class GarantieController : ControllerBase
    {
        private IGarantie _context;
        public GarantieController(IGarantie service)
        {
            _context = service;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Garantie> GetGarantiesList()
        {
            List<Garantie> GarantieList;
            try
            {
                GarantieList = _context.GetGarantiesList().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return GarantieList;
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetGarantieById([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var Garantie = _context.GetGarantieDetailsById(id);
                if (Garantie == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Garantie not found";
                    return Ok(model);
                }
                return Ok(Garantie);
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
        public IActionResult SaveGarantie([Required(ErrorMessage = "The Libele field is required")] string Libele
                                            , [Required(ErrorMessage = "The Code field is required")] string Code
                                            , [Required(ErrorMessage = "The Id_Type_Garantie  field is required")] int Id_Type_Garantie
                                        )
        {
            ResponseModel model = new ResponseModel();
            Garantie GarantieModel = new Garantie();
            GarantieModel.CodeGarantie = Code;
            GarantieModel.LibeleGarantie = Libele;
            TypeGarantie TypeGar = _context.GetGarantieTypeById(Id_Type_Garantie);
            if(TypeGar == null)
            {
                model.IsSuccess = false;
                model.Message = "Type of Garantie not found";
                return Ok(model);
            }
            GarantieModel.TypeGarantie = TypeGar;
            try
            {
                model = _context.SaveGarantie(GarantieModel);
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
        public IActionResult DeleteGarantie([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                model = _context.DeleteGarantie(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex;
                return Ok(model);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public List<ListGarantieByContrat> GetListGarantieByContrat([Required] int IdContrat)
        {
            List<ListGarantieByContrat> ListGarantie;
            try
            {
                ListGarantie = _context.GetListGarantieByContrat(IdContrat).ToList();
                return ListGarantie;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
