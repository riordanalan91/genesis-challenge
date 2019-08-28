using Genesis.Challenge.Api.Models;
using Genesis.Challenge.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Genesis.Challenge.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _users;
        private readonly IAuthenticationService _auth;

        public UserController(IUsersService userService, IAuthenticationService authService)
        {
            _users = userService;
            _auth = authService;
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
            else
            {
                var userId = user.Id.ToString();
                var token = _auth.GenerateJwt(user.Id);

                user = _users.Update(userId, token: token); 
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
                var userId = user.Id.ToString();
                var token = _auth.GenerateJwt(user.Id);
                var nowDateString = DateTime.UtcNow.ToString();

                user = _users.Update(userId, 
                    token: token, 
                    lastLoginOnUtc: nowDateString,
                    lastUpdatedOnUtc: nowDateString);

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