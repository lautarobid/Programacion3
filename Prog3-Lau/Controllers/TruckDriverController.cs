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
    public class TruckDriverController : ControllerBase
    {
        private readonly TruckDriverService _truckDriverService;

        public TruckDriverController(TruckDriverService truckDriverService)
        {
            _truckDriverService = truckDriverService;
        }

        // Obtener todos los conductores
        [HttpGet]
        public IActionResult GetAllDrivers()
        {
            var drivers = _truckDriverService.GetAllDrivers();
            return Ok(drivers); // Retorna 200 con la lista de conductores
        }

        // Obtener un conductor por DNI
        [HttpGet("{dni}")]
        public IActionResult GetDriverByDni(string dni)
        {
            var driver = _truckDriverService.GetDriverByDni(dni);
            if (driver == null)
                return NotFound($"No se encontró un conductor con el DNI {dni}"); // Retorna 404 si no se encuentra

            return Ok(driver); // Retorna 200 con el conductor encontrado
        }

        // Agregar un nuevo conductor
        [HttpPost]
        public IActionResult AddDriver([FromBody] TruckDriverForCreationDto driverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna 400 si el modelo es inválido

            _truckDriverService.AddDriver(driverDto);
            return CreatedAtAction(nameof(GetDriverByDni), new { dni = driverDto.Dni }, driverDto); // Retorna 201 con el conductor creado
        }

        // Actualizar un conductor por DNI
        [HttpPut("{dni}")]
        public IActionResult UpdateDriver(string dni, [FromBody] TruckDriverForUpdateDto driverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna 400 si el modelo es inválido

            var result = _truckDriverService.UpdateDriver(dni, driverDto);
            if (!result)
                return NotFound($"No se encontró un conductor con el DNI {dni}"); // Retorna 404 si no se encuentra

            return NoContent(); // Retorna 204 si la actualización fue exitosa
        }

        // Eliminar un conductor por DNI
        [HttpDelete("{dni}")]
        public IActionResult DeleteDriver(string dni)
        {
            var result = _truckDriverService.DeleteDriver(dni);
            if (!result)
                return NotFound($"No se encontró un conductor con el DNI {dni}"); // Retorna 404 si no se encuentra

            return NoContent(); // Retorna 204 si la eliminación fue exitosa
        }
    }
}