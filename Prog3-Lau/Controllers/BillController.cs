using Aplication.Dtos;
using Aplication.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prog3_Lau.Controllers

{
    [Route("api/[controller]")]
    [ApiController]

    public class BillController : Controller
    {
        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = billService;
        }

        // GET: BillController
        [HttpGet]
        public ActionResult Index()
        {
            var bills = _billService.GetAllBills();
            return View(bills);
        }

        // GET: BillController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var bill = _billService.GetBillById(id);
            if (bill == null)
                return NotFound();

            return View(bill);
        }

        // GET: BillController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BillForCreationDto billDto)
        {
            try
            {
                _billService.AddBill(billDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(billDto);
            }
        }

        // GET: BillController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bill = _billService.GetBillById(id);
            if (bill == null)
                return NotFound();

            return View(bill);
        }

        // POST: BillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BillForUpdateDto billDto)
        {
            try
            {
                var result = _billService.UpdateBill(id, billDto);
                if (!result)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(billDto);
            }
        }

        // GET: BillController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bill = _billService.GetBillById(id);
            if (bill == null)
                return NotFound();

            return View(bill);
        }

        // POST: BillController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _billService.DeleteBill(id);
                if (!result)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}