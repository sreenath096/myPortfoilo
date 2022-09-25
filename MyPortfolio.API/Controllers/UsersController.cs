using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using MyPortfolio.BAL.Factory;
using MyPortfolio.Models.Request.Users;
using portfoiloApi.Controllers;

namespace MyPortfolio.API.Controllers
{
    public class UsersController : BaseApiController
    {        
        private readonly IFeatureManager _featureManager;

        public UsersController(IServiceFactory serviceFactory,             
            IFeatureManager featureManager)
            : base(serviceFactory)
        {
            _featureManager = featureManager;            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _serviceFactory.UserService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _serviceFactory.UserService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CreateRequest request)
        {
            _serviceFactory.UserService.Create(request);
            return Ok(new { message = "User Created" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest request)
        {
            _serviceFactory.UserService.Update(id, request);
            return Ok(new { message = "User updated" });
        }

        [HttpPatch("{id}")]
        [FeatureGate("UpdatePasswordEnabled")]
        public IActionResult Update(int id, UpdatePasswordRequest request)
        {
            _serviceFactory.UserService.UpdatePassword(id, request);
            return Ok(new { message = "User password updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceFactory.UserService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}