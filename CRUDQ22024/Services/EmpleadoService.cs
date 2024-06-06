
using CRUDQ22024.Models;
using SQLite;

namespace CRUDQ22024.Services
{
    public class EmpleadoService
    {
        private readonly SQLiteConnection dbConnection;

        public EmpleadoService()
        {
            // Construir ruta
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");
            
            //Inicializamos el objeto
            dbConnection = new SQLiteConnection(dbPath);
            
            //Creamos la tabla Empleado
            dbConnection.CreateTable<Empleado>();
        }

        public List<Empleado> GetAll() {
            var res = dbConnection.Table<Empleado>().ToList();
            return res;
        }

        public int Insert(Empleado empleado)
        {
            return dbConnection.Insert(empleado);
        }
    }
}
