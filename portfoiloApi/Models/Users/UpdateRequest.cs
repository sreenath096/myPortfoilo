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
        
        public string? MobileNumber { get; set; }
    }
}