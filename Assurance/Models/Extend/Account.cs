    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class Account
    {
        [Required(ErrorMessage = "The username field is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "The username field is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
