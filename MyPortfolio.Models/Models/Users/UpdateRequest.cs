using MyPortfolio.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models.Models.Users
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
