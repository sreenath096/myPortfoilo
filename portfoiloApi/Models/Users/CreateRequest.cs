using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using portfoiloApi.Common.Enums;

namespace portfoiloApi.Models.Users
{
    public class CreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? MobileNumber { get; set; }
    }
}