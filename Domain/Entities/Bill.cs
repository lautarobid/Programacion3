using Domain.Enum;

namespace Domain.Entities
{
    public class Bill
    {

        public int Id { get; set; }    
        public float? Amount { get; set; }    
        public PayState? PayState { get; set; }  

    }
}
