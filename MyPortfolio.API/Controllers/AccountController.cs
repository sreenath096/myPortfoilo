using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BAL.Factory;
using portfoiloApi.Controllers;
using MyPortfolio.Models.Request.Login;

namespace MyPortfolio.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IServiceFactory serviceFactory) 
            : base(serviceFactory)
        {
            
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var users = _serviceFactory.UserService.GetAll();
            var user = users.SingleOrDefault(x => x.FirstName == request.Username);
            if (user == null) return Unauthorized("Invalid username and/or password");

            bool isValid = _serviceFactory.LoginService.ValidatePassword(user.PasswordHash, request.Password);
            if (isValid)
                return Ok("Login Successful");
            else
                return Unauthorized("Invalid username and/or password");
        }
    }
}
