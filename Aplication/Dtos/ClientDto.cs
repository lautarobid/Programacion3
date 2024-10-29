using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplication.Dtos
{ 
    public class ClientDto
 
        // Propiedades necesarias para transferir datos
{
            public required string IdClient { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public required string PayState { get; set; }
    }

}