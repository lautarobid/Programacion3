namespace Domain.Entities
{
    public class Admin : User
    {
        // Propiedad para el nivel de acceso
        public string AccessLevel { get; set; }

        // Método para asignar permisos
        public void AssignPermissions()
        {
            // Lógica de asignación de permisos (por definir)
        }
    }
}