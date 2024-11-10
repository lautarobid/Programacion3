using Aplication.Interfaces;
using Aplication.Models.Mappings;
using Aplication.Models.Request;
using Domain.Entities;
using Infrastructure.Repositories;
using System.Collections.Generic;

namespace Aplication.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly BillMapping _billMapping;

        public ClientService(IClientRepository clientRepository, BillMapping billMapping)
        {
            _clientRepository = clientRepository;
            _billMapping = billMapping;
        }

        public void AddBill(int clientId, Bill bill)
        {
            var client = _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            client.Bills.Add(bill);
            _clientRepository.Update(client);
        }

        public void AddTrip(int clientId, Trip trip)
        {
            var client = _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            client.Trips.Add(trip);
            _clientRepository.Update(client);
        }

        public Bill AddBillToClient(int clientId, BillRequest billRequest)
        {
            var client = _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            var bill = _billMapping.MapBillRequestToEntity(billRequest);
            client.Bills.Add(bill);
            _clientRepository.Update(client);

            return bill; // Devuelve la factura creada
        }

        public List<Bill> GetBillsByClientId(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            return client.Bills;
        }
    }
}