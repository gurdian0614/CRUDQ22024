
using SQLite;

namespace CRUDQ22024.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set;}

        public string Email { get; set;}

        public string Direccion { get; set;}

    }
}
