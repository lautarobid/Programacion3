using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Restringir acceso solo a administradores
    public class AdminController : ControllerBase
    {
        private readonly ITruckDriverService _truckDriverService;
        private readonly ITripService _tripService;

        public AdminController(ITruckDriverService truckDriverService, ITripService tripService)
        {
            _truckDriverService = truckDriverService;
            _tripService = tripService;
        }

        // Obtener la lista de conductores
        [HttpGet("DriverList")]
        public async Task<ActionResult<List<TruckDriver>>> GetDriverListAsync(CancellationToken cancellationToken = default)
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

        // Obtener la lista de viajes
        [HttpGet("TravelList")]
        public async Task<ActionResult<List<Trip>>> GetTravelListAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var trips = await _tripService.GetAllTripsAsync(cancellationToken);
                return Ok(trips);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}