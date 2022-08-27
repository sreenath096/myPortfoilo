using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using portfoiloApi.Common.Enums;
using portfoiloApi.Common.Extensions;

namespace portfoiloApi.Models.Users
{
    public class UpdateRequest
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [EnumDataType(typeof(Role))]
        public Role? Role { get; set; }
        private string? _password;
        [MinLength(6)]
        public string? Password
        {
            get => _password;
            set => _password = value?.ReplaceEmptyStringWithNull();
        }
        private string? _confirmPassword;
        [Compare("Password")]
        public string? ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = value?.ReplaceEmptyStringWithNull();
        }
        public string? MobileNumber { get; set; }
    }
}