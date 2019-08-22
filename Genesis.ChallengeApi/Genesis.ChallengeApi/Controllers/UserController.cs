using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Challenge.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/user
        [HttpPost]
        public ActionResult<UserModel> CreateUser([FromBody] UserCreationModel model)
        {
            return null;
        }

        // POST api/user/login
        [HttpPost]
        [Route("Login")]
        public ActionResult<UserModel> Login([FromBody] LoginModel model)
        {
            return null;
        }

        // GET api/user/{GUID}
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<UserModel> SearchUser(string userId)
        {
            return null;
        }
    }
}