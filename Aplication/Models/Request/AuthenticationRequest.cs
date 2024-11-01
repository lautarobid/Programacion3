﻿using System.ComponentModel.DataAnnotations;

namespace Aplication.Models.Request
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
