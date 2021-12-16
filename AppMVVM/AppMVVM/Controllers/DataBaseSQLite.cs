using AppMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVM.Controllers
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        // Constructor de la clase DataBaseSQLite

        public DataBaseSQLite(String pathdb)
        {

            // Crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            // Creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Empleados>().Wait();
        }

        // Operaciones CRUD con SQLite
        // READ List Way

        public Task<List<Empleados>> ObtenerListaPersonas()
        {
            return db.Table<Empleados>().ToListAsync();
        }

        //READ one by one
        public Task<Empleados> ObtenerPersona(int pcodigo)
        {
            return db.Table<Empleados>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }


        // CREATE persona
        public Task<int> GrabarPersonas(Empleados empleados)
        {
            if (empleados.codigo != 0)
            {
                return db.UpdateAsync(empleados);
            }
            else
            {
                return db.InsertAsync(empleados);
            }
        }

        //DELETE

        public Task<int> EliminarPersonas(Empleados empleados)
        {
            return db.DeleteAsync(empleados);
        }

    }
}
