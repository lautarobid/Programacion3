using Aplication.Interfaces;
using Aplication.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ClientOnly")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        // POST: api/Trip
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] TripRequest tripRequest)
        {
            var createdTrip = await _tripService.CreateTripAsync(tripRequest);
            return CreatedAtAction(nameof(GetTripById), new { id = createdTrip.Id }, createdTrip);
        }

        // PUT: api/Trip/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] TripRequest tripRequest)
        {
            var updatedTrip = await _tripService.UpdateTripAsync(id, tripRequest);
            return Ok(updatedTrip);
        }

        // GET: api/Trip/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var trip = await _tripService.GetTripByIdAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        // DELETE: api/Trip/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                await _tripService.DeleteTripAsync(id, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
