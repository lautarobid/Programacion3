
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "TruckDriver")] // Restricción de acceso para usuarios con el rol TruckDriver
    public class TruckDriverController : ControllerBase
    {
        private readonly ITruckDriverService _truckDriverService;

        public TruckDriverController(ITruckDriverService truckDriverService)
        {
            _truckDriverService = truckDriverService;
        }

        // Obtener todos los conductores disponibles
        [HttpGet("available")]
        public async Task<ActionResult<List<TruckDriver>>> GetAvailableDriversAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var drivers = await _truckDriverService.GetAvailableDriversAsync(cancellationToken);
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obtener un conductor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckDriver>> GetTruckDriverByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var driver = await _truckDriverService.GetTruckDriverByIdAsync(id, cancellationToken);
                if (driver == null)
                {
                    return NotFound("Conductor no encontrado");
                }
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Agregar un nuevo conductor
        [HttpPost]
        public async Task<ActionResult<TruckDriver>> AddTruckDriverAsync([FromBody] TruckDriver driver, CancellationToken cancellationToken = default)
        {
            try
            {
                var newDriver = await _truckDriverService.AddTruckDriverAsync(driver, cancellationToken);
                return CreatedAtAction(nameof(GetTruckDriverByIdAsync), new { id = newDriver.Id }, newDriver);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Actualizar un conductor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTruckDriverAsync(int id, [FromBody] TruckDriver driver, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingDriver = await _truckDriverService.GetTruckDriverByIdAsync(id, cancellationToken);
                if (existingDriver == null)
                {
                    return NotFound("Conductor no encontrado");
                }

                await _truckDriverService.UpdateTruckDriverAsync(driver, cancellationToken);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Eliminar un conductor por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruckDriverAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingDriver = await _truckDriverService.GetTruckDriverByIdAsync(id, cancellationToken);
                if (existingDriver == null)
                {
                    return NotFound("Conductor no encontrado");
                }

                await _truckDriverService.DeleteTruckDriverAsync(id, cancellationToken);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}