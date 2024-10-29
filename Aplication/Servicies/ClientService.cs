using Aplication.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        // Constructor que inyecta el repositorio de clientes
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // Método para obtener un cliente por ID y convertirlo a ClientDto
        public ClientDto GetClientById(string idClient)
        {
            var client = _clientRepository.GetById(idClient);
            if (client == null)
                throw new KeyNotFoundException($"Client with ID {idClient} was not found.");

            return ConvertToDto(client);
        }

        // Método para obtener todos los clientes en formato ClientDto
        public List<ClientDto> GetAllClients()
        {
            var clients = _clientRepository.GetAll();
            return clients.Select(ConvertToDto).ToList();
        }

        // Método para agregar un nuevo cliente utilizando ClientAdd
        public void AddClient(ClientAdd clientAdd)
        {
            var client = new Client
            {
                IdClient = Guid.NewGuid().ToString(),
                Name = clientAdd.Name,
                LastName = clientAdd.LastName,
                Email = clientAdd.Email,
                Password = clientAdd.Password,  // Asigna la contraseña desde ClientAdd
                Bill = new Bill { PayState = clientAdd.PayState } // Estado de pago inicial
            };

            _clientRepository.Add(client);
        }

        // Método para actualizar un cliente existente
        public bool UpdateClient(string idClient, ClientDto clientDto)
        {
            var client = _clientRepository.GetById(idClient);
            if (client == null) return false;

            client.Name = clientDto.Name;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.Bill.PayState = clientDto.PayState;

            _clientRepository.Update(client);
            return true;
        }

        // Método para eliminar un cliente por ID
        public bool DeleteClient(string idClient)
        {
            var client = _clientRepository.GetById(idClient);
            if (client == null) return false;

            _clientRepository.Delete(client);
            return true;
        }

        // Método privado para convertir un Client a ClientDto
        private ClientDto ConvertToDto(Client client)
        {
            return new ClientDto
            {
                IdClient = client.IdClient,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Password = client.Password,
                PayState = client.Bill.PayState
            };
        }
    }
}