using Afte.Database;
using Afte.Models.ViewModels.User;
using Afte.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Afte.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AfteDbContext _context;

        public UsersController(AfteDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            var userService = new UserService(_context);
            var usuarios = await userService.GetUsers();

            return Ok(usuarios);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            var userService = new UserService(_context);
            var usuario = await userService.GetUserById(userId);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel user)
        {
            var userService = new UserService(_context);
            await userService.CreateUser(user);

            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> RegisterUserData([FromRoute] long userId, [FromBody] UpdateUserViewModel user)
        {
            var userService = new UserService(_context);
            await userService.RegisterUserData(user, userId);

            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long userId)
        {
            var userService = new UserService(_context);
            await userService.DeleteUser(userId);

            return Ok();
        }
    }
}
