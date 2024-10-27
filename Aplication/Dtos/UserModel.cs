using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class UserModel
    {
        public int Id { get; internal set; }
        public required string UserName { get; set; }  // Cambia internal a public
        public required string Password { get; set; }  // Cambia internal a public
        public required string Email { get; set; }     // Cambia internal a public
        public required string Name { get; set; }      // Cambia internal a public
    }
}