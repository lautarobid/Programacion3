using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener un cliente por ID
        public Client GetById(string idClient)
        {
            return _context.Clients.FirstOrDefault(c => c.IdClient == idClient);
        }

        // Obtener todos los clientes
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        // Agregar un nuevo cliente
        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        // Actualizar un cliente existente
        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        // Eliminar un cliente
        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}