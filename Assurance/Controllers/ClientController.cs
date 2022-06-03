using Assurance.Models;
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
    public class ClientController : ControllerBase
    {
        private IClient _context;
        public ClientController(IClient service)
        {
            _context = service;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Client> GetClientsList()
        {
            List<Client> ClientList;
            try
            {
                ClientList = _context.GetClientsList().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return ClientList;
        }

            [HttpGet]
            [Route("[action]/id")]
            public IActionResult GetClientById([Required] int id)
            {
                ResponseModel model = new ResponseModel();
                try
                {
                    var client = _context.GetClientDetailsById(id);
                    if (client == null)
                    {
                        model.IsSuccess = false;
                        model.Message = "Client not found";
                        return Ok(model);
                    }
                    return Ok(client);
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
        public IActionResult SaveClient([StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
                                    [Required(ErrorMessage = "The First Name field is required")] string FirstName,
                                    [Required(ErrorMessage = "The Last Name field is required")]
                                    [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)] string LastName,
                                    [Required(ErrorMessage = "The CIN field is required")] long CIN,
                                    [Required(ErrorMessage = "The Phone Number filed is required")] string phone,
                                    [Required] [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")] string Email,string Address, string Country, int? codePostal)
        {
            Client clientModel = new Client();
            clientModel.FirstName = FirstName;
            clientModel.LastName = LastName;
            clientModel.CIN = CIN;
            clientModel.Phone = phone;
            clientModel.Email = Email;
            clientModel.Address = Address;
            clientModel.Country = Country;
            clientModel.CodePostal = codePostal;

            ResponseModel model = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    model = _context.SaveClient(clientModel);
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Error";
                }
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
        public IActionResult DeleteClient([Required] int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                model = _context.DeleteClient(id);
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
        public List<NbrContratParClient> GetNbrContratParClient([Required] int IdClient)
        {
            List<NbrContratParClient> InfoList;
            try
            {
                InfoList = _context.GetNbrContratParClient(IdClient).ToList();
                return InfoList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
