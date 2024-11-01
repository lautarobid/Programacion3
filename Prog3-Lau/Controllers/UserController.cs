using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Aplication.Models.Request;

namespace Prog3_Lau.Controllers
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


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest("El objeto UserRequest no puede ser nulo.");
            }

            await _userService.CreateUserAsync(userRequest);
            return Ok("Usuario creado exitosamente!");
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(int userId, [FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest("El objeto UserRequest no puede ser nulo.");
            }
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(userId, userRequest);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
