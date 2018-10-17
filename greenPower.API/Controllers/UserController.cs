using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using greenPower.Infrastructure.Commands;
using greenPower.Infrastructure.Commands.Users;
using greenPower.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace greenPower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : APIControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.Get(email);

            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }


        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }

    }
}
