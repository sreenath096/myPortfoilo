using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models.Request.Login
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}
