using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using portfoiloApi.Models.Users;
using portfoiloApi.Services;

namespace portfoiloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
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