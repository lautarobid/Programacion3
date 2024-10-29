using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class BillDto
    {
        public required int IdBill { get; set; }
        public required float Mount { get; set; }
        public required string PayState { get; set; }
    }

    public class BillForCreationDto
    {
        public required float Mount { get; set; }
        public required string PayState { get; set; }
    }

    public class BillForUpdateDto
    {
        public required float Mount { get; set; }
        public required string PayState { get; set; }
    }
}
