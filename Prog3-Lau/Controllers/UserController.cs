using Aplication.Dtos;
using Aplication.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpGet("{name}")]
        public IActionResult Get([FromRoute] string name)
        {
            return Ok(_service.Get(name));
        }
        [HttpPost]
        public IActionResult Add([FromBody] UserForAddRequest body)
        {
            return Ok(_service.AddUser(body));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteUser(id);
            if (result)
            {
                return NoContent(); // Retorna 204 si se eliminó con éxito
            }
            return NotFound(); // Retorna 404 si no se encontró el usuario
        }
    }
}
