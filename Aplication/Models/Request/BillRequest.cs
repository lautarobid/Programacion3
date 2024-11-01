using Domain.Enum;

namespace Aplication.Models.Request
{
    public class BillRequest
    {
        public float? Amount { get; set; }
        public PayState? PayState { get; set; }
    }
}