using Aplication.Interfaces;
using Aplication.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomAuthenticationService _customAuthenticationService;
        public AuthController(ICustomAuthenticationService customAuthenticationService)
        {
            _customAuthenticationService = customAuthenticationService;
        }
        [HttpPost]
        public async Task<ActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            try
            {
                var token = await _customAuthenticationService.AutenticarAsync(request);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
