using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using MyPortfolio.BAL;
using MyPortfolio.Models.Models.Users;

namespace portfoiloApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IFeatureManager _featureManager;

        public UsersController(IUserService userService, IFeatureManager featureManager)
        {
            _featureManager = featureManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _userService.Create(model);
            return Ok(new { message = "User Created" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated" });
        }

        [HttpPatch("{id}")]
        [FeatureGate("UpdatePasswordEnabled")]
        public IActionResult Update(int id, UpdatePasswordRequest model)
        {
            _userService.UpdatePassword(id, model);
            return Ok(new { message = "User password updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}