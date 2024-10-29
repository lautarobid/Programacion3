using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBillRepository
    {
        List<Bill> GetAll();
        Bill? GetById(int idBill);   // Cambia 'string' a 'int' para que coincida con el tipo en el modelo Bill
        int Add(Bill bill);          // Cambia el tipo de retorno a 'int' en lugar de 'string'
        void Update(Bill bill);
        void Delete(Bill bill);
    }
}