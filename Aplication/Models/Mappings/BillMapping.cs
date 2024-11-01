using Aplication.Models.Request;
using Aplication.Models.Response;
using Domain.Entities;

namespace Aplication.Models.Mappings
{
    public class BillMapping
    {
        public Bill MapBillRequestToEntity(BillRequest billRequest)
        {
            return new Bill
            {
                Amount = billRequest.Amount,
                PayState = billRequest.PayState
            };
        }
        public BillResponse MapBillToResponse(Bill bill)
        {
            return new BillResponse
            {
                Id = bill.Id,
                Amount = bill.Amount,
                PayState = bill.PayState
            };
        }
        public Bill UpdateBillFromRequest(Bill bill, BillRequest billRequest)
        {
            bill.Amount = billRequest.Amount ?? bill.Amount;
            bill.PayState = billRequest.PayState ?? bill.PayState;
            return bill;
        }
    }
}
