using Aplication.Models.Request;
using Domain.Entities;
using System.Collections.Generic;

namespace Aplication.Interfaces
{
    public interface IClientService
    {
        void AddBill(int clientId, Bill bill);
        void AddTrip(int clientId, Trip trip);
        Bill AddBillToClient(int clientId, BillRequest billRequest); // Cambia de void a Bill
        List<Bill> GetBillsByClientId(int clientId); // Agrega este método
    }
}