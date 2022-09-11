﻿using MyPortfolio.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models.Models.Users
{
    public class CreateRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        public string? MobileNumber { get; set; }
    }
}
