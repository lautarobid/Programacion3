using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class BillDto
    {
        public int IdBill { get; set; }
        public float Mount { get; set; }
        public string PayState { get; set; }
    }

    public class BillForCreationDto
    {
        public float Mount { get; set; }
        public string PayState { get; set; }
    }

    public class BillForUpdateDto
    {
        public float Mount { get; set; }
        public string PayState { get; set; }
    }
}
