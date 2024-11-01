﻿using Domain.Enum;

namespace Aplication.Models.Request
{
    public class UserRequest
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
    }
}
