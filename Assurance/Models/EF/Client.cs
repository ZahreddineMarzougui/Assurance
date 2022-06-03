using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assurance.Models.EF
{
    public class Client : IdentityUser<Guid>
    {
        [Key, Required]
        public int IdClient { get; set; }
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "The First Name field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The CIN field is required")]

        public long CIN { get; set; }

        [Required(ErrorMessage = "The Phone Number filed is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email format is not correct.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int? CodePostal { get; set; }

        public ICollection<Contrat> Contrat { get; set; }
    }

}
