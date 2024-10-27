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
        public required string UserName { get; internal set; }
        public required string Password { get; internal set; }
        public required string Email { get; internal set; }
        public required string Name { get; internal set; }
    }
}
