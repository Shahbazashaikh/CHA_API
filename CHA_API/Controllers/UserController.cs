using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHA_API.Service;
using CHA_API.Model.RequestModel;

namespace CHA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("AuthenticateUser")]
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(UserLoginRequest userLoginRequest)
        {
            return Ok(await _userService.AuthenticateUser(userLoginRequest));
        }
    }
}
