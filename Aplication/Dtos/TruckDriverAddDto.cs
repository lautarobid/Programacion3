using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class TruckDriverForCreationDto
    {
        [Required]
        public required string Dni { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        public required string TruckPatent { get; set; }
    }
}