namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        // Obtener una entidad por su ID
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

        // Listar todas las entidades
        Task<List<T>> ListAsync(CancellationToken cancellationToken = default);

        // Agregar una nueva entidad
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        // Actualizar una entidad existente
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        // Eliminar una entidad
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        // Guardar cambios en el contexto
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}