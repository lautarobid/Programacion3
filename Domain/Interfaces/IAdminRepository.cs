using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository : IRepositoryBase<Admin>
    {
        // Aquí puedes agregar métodos específicos para la entidad Admin si son necesarios
    }
}