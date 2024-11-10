using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aplication.Models.Request;
using Aplication.Models.Response;
using Aplication.Models.Mappings;
using Aplication.Interfaces;
using Domain.Entities;

namespace Prog3_Lau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IBillMapping _billMapping;

        public ClientController(IClientService clientService, IBillMapping billMapping)
        {
            _clientService = clientService;
            _billMapping = billMapping;
        }

        /// <summary>
        /// Agrega una factura (Bill) a un cliente.
        /// </summary>
        /// <param name="clientId">Id del cliente</param>
        /// <param name="billRequest">Datos de la factura</param>
        /// <returns>La factura creada</returns>
        [HttpPost("{clientId}/add-bill")]
        public IActionResult AddBill(int clientId, [FromBody] BillRequest billRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto<string>
                {
                    Success = false,
                    Message = "Invalid model",
                    Data = null
                });
            }

            try
            {
                var bill = _clientService.AddBillToClient(clientId, billRequest);

                return Ok(new ResponseDto<BillResponse>
                {
                    Success = true,
                    Message = "Bill added successfully",
                    Data = _billMapping.MapBillToResponse(bill)
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new ResponseDto<string>
                {
                    Success = false,
                    Message = "Client not found",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<string>
                {
                    Success = false,
                    Message = "An error occurred while adding the bill",
                    Data = null
                });
            }
        }

        /// <summary>
        /// Agrega un viaje (Trip) a un cliente.
        /// </summary>
        /// <param name="clientId">Id del cliente</param>
        /// <param name="tripRequest">Datos del viaje</param>
        /// <returns>El viaje creado</returns>
        [HttpPost("{clientId}/add-trip")]
        public IActionResult AddTrip(int clientId, [FromBody] TripRequest tripRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto<string>
                {
                    Success = false,
                    Message = "Invalid model",
                    Data = null
                });
            }

            try
            {
                _clientService.AddTrip(clientId, new Trip
                {
                    StartingPoint = tripRequest.StartingPoint,
                    Destination = tripRequest.Destination,
                    DepartureDate = tripRequest.DepartureDate
                });

                return Ok(new ResponseDto<string>
                {
                    Success = true,
                    Message = "Trip added successfully",
                    Data = null
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new ResponseDto<string>
                {
                    Success = false,
                    Message = "Client not found",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<string>
                {
                    Success = false,
                    Message = "An error occurred while adding the trip",
                    Data = null
                });
            }
        }
    }
}