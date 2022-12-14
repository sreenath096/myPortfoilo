using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models.Request.Users
{
    public class UpdatePasswordRequest
    {
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
