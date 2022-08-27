using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using portfoiloApi.Common.Enums;

namespace portfoiloApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        //[JsonIgnore]
        public string PasswordHash { get; set; }
        public string? MobileNumber { get; set; }

    }
}