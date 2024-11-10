using Aplication.Models.Request;
using Aplication.Models.Response;
using Domain.Entities;
using Domain.Enum;

namespace Aplication.Models.Mappings
{
    public class BillMapping
    {
        /// <summary>
        /// Mapea un objeto BillRequest a una entidad Bill.
        /// </summary>
        /// <param name="billRequest">Objeto de solicitud con los datos de la factura.</param>
        /// <returns>Una entidad Bill.</returns>
        public Bill MapBillRequestToEntity(BillRequest billRequest)
        {
            if (billRequest == null)
            {
                throw new ArgumentNullException(nameof(billRequest), "BillRequest cannot be null");
            }

            return new Bill
            {
                Amount = billRequest.Amount.GetValueOrDefault(0), // Manejo seguro del nullable
                PayState = billRequest.PayState ?? PayState.noPago // Valor por defecto si es null
            };
        }

        /// <summary>
        /// Mapea una entidad Bill a un objeto de respuesta BillResponse.
        /// </summary>
        /// <param name="bill">Entidad Bill con los datos de la factura.</param>
        /// <returns>Un objeto de respuesta BillResponse.</returns>
        public BillResponse MapBillToResponse(Bill bill)
        {
            if (bill == null)
            {
                throw new ArgumentNullException(nameof(bill), "Bill cannot be null");
            }

            return new BillResponse
            {
                Id = bill.Id,
                Amount = bill.Amount,
                PayState = bill.PayState
            };
        }

        /// <summary>
        /// Actualiza los datos de una entidad Bill a partir de un objeto BillRequest.
        /// </summary>
        /// <param name="bill">Entidad Bill a actualizar.</param>
        /// <param name="billRequest">Objeto de solicitud con los nuevos datos.</param>
        /// <returns>La entidad Bill actualizada.</returns>
        public Bill UpdateBillFromRequest(Bill bill, BillRequest billRequest)
        {
            if (bill == null)
            {
                throw new ArgumentNullException(nameof(bill), "Bill cannot be null");
            }

            if (billRequest == null)
            {
                throw new ArgumentNullException(nameof(billRequest), "BillRequest cannot be null");
            }

            bill.Amount = billRequest.Amount ?? bill.Amount;
            bill.PayState = billRequest.PayState ?? bill.PayState;

            return bill;
        }
    }
}