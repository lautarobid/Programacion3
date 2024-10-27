using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class UserForAddRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public required string LastName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
    }
}