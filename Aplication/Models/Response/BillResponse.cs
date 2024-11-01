using Domain.Enum;

namespace Aplication.Models.Response
{
    public class BillResponse
    {
        public int Id { get; set; }
        public float? Amount { get; set; }
        public PayState? PayState { get; set; }
    }
}