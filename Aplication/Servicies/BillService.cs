using Domain.Entities;
using Aplication.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Servicies
{
    public class BillService
    {
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        // Método para obtener todas las facturas
        public List<BillDto> GetAllBills()
        {
            var bills = _billRepository.GetAll();
            return bills.Select(b => new BillDto
            {
                IdBill = b.IdBill,
                Mount = b.Mount,
                PayState = b.PayState
            }).ToList();
        }

        // Método para obtener una factura por ID
        public BillDto? GetBillById(int idBill)
        {
            var bill = _billRepository.GetById(idBill);
            if (bill == null) return null;

            return new BillDto
            {
                IdBill = bill.IdBill,
                Mount = bill.Mount,
                PayState = bill.PayState
            };
        }

        // Método para agregar una nueva factura
        public int AddBill(BillForCreationDto billDto)
        {
            var bill = new Bill
            {
                Mount = billDto.Mount,
                PayState = billDto.PayState
            };

            return _billRepository.Add(bill);
        }

        // Método para actualizar una factura existente
        public bool UpdateBill(int idBill, BillForUpdateDto billDto)
        {
            var existingBill = _billRepository.GetById(idBill);
            if (existingBill == null)
            {
                return false;
            }

            existingBill.Mount = billDto.Mount;
            existingBill.PayState = billDto.PayState;

            _billRepository.Update(existingBill);
            return true;
        }

        // Método para eliminar una factura
        public bool DeleteBill(int idBill)
        {
            var bill = _billRepository.GetById(idBill);
            if (bill == null)
            {
                return false;
            }

            _billRepository.Delete(bill);
            return true;
        }
    }
}