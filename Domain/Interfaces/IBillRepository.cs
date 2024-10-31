using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBillRepository
    {
        List<Bill> GetAll();
        Bill? GetById(int idBill); // Usa este para obtener facturas por ID
        int Add(Bill bill);
        void Update(Bill bill); // Usa este para actualizar facturas
        void Delete(Bill bill);
    }
}