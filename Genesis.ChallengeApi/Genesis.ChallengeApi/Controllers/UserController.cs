using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Challenge.Api.Models;
using Genesis.Challenge.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.Challenge.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _users;

        public UserController(IUsersService userService)
        {
            _users = userService;
        }

        // POST api/user
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserModel> CreateUser([FromBody] UserCreationModel model)
        {
            var user = _users.Create(model);
            if (user == null)
            {
                return BadRequest("Email already exists!");
            }
            return Ok(user);
        }

        // POST api/user/login
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult<UserModel> Login([FromBody] LoginModel model)
        {
            var user = _users.AuthenticateUser(model.Email, model.Password);
            if (user == null)
            {
                return BadRequest("Invalid user and / or password");
            }
            else
            {
                return Ok(user);
            }
        }

        // GET api/user/{GUID}
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<UserModel> SearchUser(string userId)
        {
            var result = _users.Get(userId);
            return Ok(result);
        }
    }
}