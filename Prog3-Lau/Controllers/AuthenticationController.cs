using Aplication.Dtos;
using Aplication.Servicies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthenticationController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
            public IActionResult Authenticate([FromBody] CredentialsRequest credentials)
            {
                UserModel userLogged = _userService.CheckCredentials(credentials);
            if (userLogged is not  null) {   
                return Ok("jwt");
            }

            return Unauthorized();
        }
     }
}
