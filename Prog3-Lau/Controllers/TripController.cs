using Aplication.Servicies;
using Aplication.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        // Obtener un viaje por ID
        [HttpGet("{idTrip:int}")]  // Especifica que idTrip es un int
        public IActionResult GetTripById(int idTrip)
        {
            var trip = _tripService.GetTripById(idTrip);
            if (trip == null)
                return NotFound($"No se encontró un viaje con el ID {idTrip}");

            return Ok(trip);
        }

        // Obtener todos los viajes
        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var trips = _tripService.GetAllTrips();
            return Ok(trips);
        }

        // Agregar un nuevo viaje
        [HttpPost]
        public IActionResult AddTrip([FromBody] TripForCreationDto tripDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTripId = _tripService.AddTrip(tripDto);
            return CreatedAtAction(nameof(GetTripById), new { idTrip = createdTripId }, tripDto);
        }

        // Actualizar un viaje existente
        [HttpPut("{idTrip:int}")]
        public IActionResult UpdateTrip(int idTrip, [FromBody] TripForUpdateDto tripDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _tripService.UpdateTrip(idTrip, tripDto);
            if (!result)
                return NotFound($"No se encontró un viaje con el ID {idTrip}");

            return NoContent();
        }

        // Eliminar un viaje por ID
        [HttpDelete("{idTrip:int}")]
        public IActionResult DeleteTrip(int idTrip)
        {
            var result = _tripService.DeleteTrip(idTrip);
            if (!result)
                return NotFound($"No se encontró un viaje con el ID {idTrip}");

            return NoContent();
        }
    }
}