using Application.Services;
using Aplication.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            try
            {
                var clientDto = _clientService.GetClientById(idClient);
                return Ok(clientDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Obtener todos los clientes
        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        // Agregar un nuevo cliente y devolver el ID
        [HttpPost]
        public IActionResult Add([FromBody] ClientAdd clientAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientId = _clientService.AddClient(clientAdd);
            return CreatedAtAction(nameof(GetById), new { idClient = clientId }, clientId);
        }

        // Actualizar un cliente por ID
        [HttpPut("{idClient}")]
        public IActionResult Update(string idClient, [FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _clientService.UpdateClient(idClient, clientDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Eliminar un cliente por ID
        [HttpDelete("{idClient}")]
        public IActionResult Delete(string idClient)
        {
            var result = _clientService.DeleteClient(idClient);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Obtener los viajes de un cliente
        [HttpGet("{idClient}/trips")]
        public IActionResult GetClientTrips(string idClient)
        {
            try
            {
                var trips = _clientService.GetClientTrips(idClient);
                return Ok(trips);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Agregar un viaje a un cliente
        [HttpPost("{idClient}/trips")]
        public IActionResult AddTripToClient(string idClient, [FromBody] Trip newTrip)
        {
            try
            {
                _clientService.AddTripToClient(idClient, newTrip);
                return Ok("Viaje agregado exitosamente.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}