
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtiene un cliente por su ID
        public Client? GetById(int clientId)
        {
            return _context.Clients
                .Include(c => c.Trips)
                .Include(c => c.Bills) // Cambiado de Bill a Bills
                .FirstOrDefault(c => c.Id == clientId);
        }

        // Obtiene todos los clientes
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                .Include(c => c.Trips)
                .Include(c => c.Bills) // Cambiado de Bill a Bills
                .ToList();
        }

        // Agrega un nuevo cliente
        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        // Actualiza un cliente existente
        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        // Elimina un cliente
        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        // Obtiene los viajes de un cliente por su ID
        public List<Trip> GetTripsByClientId(int clientId)
        {
            var client = _context.Clients
                .Include(c => c.Trips)
                .FirstOrDefault(c => c.Id == clientId);

            return client?.Trips ?? new List<Trip>();
        }

        // Obtiene las facturas de un cliente por su ID
        public List<Bill> GetBillsByClientId(int clientId)
        {
            var client = _context.Clients
                .Include(c => c.Bills) // Cambiado de Bill a Bills
                .FirstOrDefault(c => c.Id == clientId);

            return client?.Bills ?? new List<Bill>();
        }
    }
}