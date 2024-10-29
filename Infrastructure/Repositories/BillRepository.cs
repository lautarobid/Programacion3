using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDBContext _context;

        public BillRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Bill> GetAll()
        {
            return _context.Bills.ToList();
        }

        public Bill? GetById(int idBill)
        {
            return _context.Bills.FirstOrDefault(b => b.IdBill == idBill);
        }

        public int Add(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill.IdBill;
        }

        public void Update(Bill bill)
        {
            _context.Bills.Update(bill);
            _context.SaveChanges();
        }

        public void Delete(Bill bill)
        {
            _context.Bills.Remove(bill);
            _context.SaveChanges();
        }
    }
}