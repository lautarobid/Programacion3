using Aplication.Dtos;
using Aplication.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = billService;
        }

        // GET: api/Bill
        [HttpGet]
        public IActionResult GetAll()
        {
            var bills = _billService.GetAllBills();
            return Ok(bills);
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bill = _billService.GetBillById(id);
            if (bill == null)
                return NotFound();

            return Ok(bill);
        }

        // POST: api/Bill
        [HttpPost]
        public IActionResult Create(BillForCreationDto billDto)
        {
            var id = _billService.AddBill(billDto);
            return CreatedAtAction(nameof(GetById), new { id }, billDto);
        }

        // PUT: api/Bill/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, BillForUpdateDto billDto)
        {
            var result = _billService.UpdateBill(id, billDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _billService.DeleteBill(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPost("pay/{idBill}")]
        public IActionResult PayBill(int idBill)
        {
            var result = _billService.ProcessPayment(idBill);
            return Ok(result);
        }
    }
}