using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class ClientAdd
    {
        [Required]
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
        public float Mount { get; set; }

        public ClientAdd() { }

        public ClientAdd(string idClient, string name, string lastName, string email, string password, string payState)
        {
            IdClient = idClient;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            PayState = payState;
        }
        public Client CreateClient(ClientAdd clientAdd)
        {
            var client = new Client
            {
                IdClient = clientAdd.IdClient,
                Name = clientAdd.Name,
                LastName = clientAdd.LastName,
                Email = clientAdd.Email,
                Password = clientAdd.Password,
                Bill = new Bill(clientAdd.Mount) { PayState = clientAdd.PayState }
            };

            return client;
        }
    }
}