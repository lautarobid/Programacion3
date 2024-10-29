using Aplication.Dtos;
using Aplication.Servicies;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        // Constructor que inyecta el servicio de clientes
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // Obtener un cliente por ID
        [HttpGet("{idClient}")]
        public IActionResult GetById(string idClient)
        {
            var clientDto = _clientService.GetClientById(idClient);
            if (clientDto == null)
                return NotFound(); // Retorna 404 si no se encuentra el cliente

            return Ok(clientDto); // Retorna 200 con los datos del cliente
        }

        // Obtener todos los clientes
        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients); // Retorna 200 con la lista de clientes
        }

        // Agregar un nuevo cliente
        [HttpPost]
        public IActionResult Add([FromBody] ClientAdd clientAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna 400 si el modelo es inválido

            _clientService.AddClient(clientAdd); // Cambia clientDto por clientAdd
            return CreatedAtAction(nameof(GetById), new { idClient = clientAdd.IdClient }, clientAdd); // Cambia clientDto por clientAdd
        }

        // Actualizar un cliente por ID
        [HttpPut("{idClient}")]
        public IActionResult Update(string idClient, [FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna 400 si el modelo es inválido

            var result = _clientService.UpdateClient(idClient, clientDto);
            if (!result)
                return NotFound(); // Retorna 404 si no se encuentra el cliente

            return NoContent(); // Retorna 204 si la actualización fue exitosa
        }

        // Eliminar un cliente por ID
        [HttpDelete("{idClient}")]
        public IActionResult Delete(string idClient)
        {
            var result = _clientService.DeleteClient(idClient);
            if (!result)
                return NotFound(); // Retorna 404 si no se encuentra el cliente

            return NoContent(); // Retorna 204 si la eliminación fue exitosa
        }
    }
}