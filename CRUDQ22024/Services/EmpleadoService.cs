
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

        /// <summary>
        /// Lista todos los empleados
        /// </summary>
        /// <returns>Una lista de empleados</returns>
        public List<Empleado> GetAll() {
            var res = dbConnection.Table<Empleado>().ToList();
            return res;
        }

        /// <summary>
        /// Guarda un empleado a la base de datos
        /// </summary>
        /// <param name="empleado">Objeto con datos del empleado a guardar</param>
        /// <returns>Cantidad de registros ingresados</returns>
        public int Insert(Empleado empleado)
        {
            return dbConnection.Insert(empleado);
        }

        /// <summary>
        /// Actualiza un empleado seleccionado
        /// </summary>
        /// <param name="empleado">Objeto con datos del empleado a actualizar</param>
        /// <returns>Cantidad de resgistros actualizados</returns>
        public int Update(Empleado empleado) 
        {
            return dbConnection.Update(empleado);
        }

        /// <summary>
        /// Elimina un empleado
        /// </summary>
        /// <param name="empleado">Objeto con datos del empleado a eliminar</param>
        /// <returns>Cantidad de resgistros eliminados</returns>
        public int Delete(Empleado empleado)
        {
            return dbConnection.Delete(empleado);
        }
    }
}
