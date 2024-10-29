using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class TruckDriverDto
    {
        public required string Dni { get; set; }
        public required string Name { get; set; }
        public  required string LastName { get; set; }
        public required string Email { get; set; }
        public required string TruckPatent { get; set; }
    }
}