using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PROEHECT.Models;
using SQLite;

namespace PROEHECT.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(String dbpath) {
            dbase = new SQLiteAsyncConnection(dbpath);
            dbase.CreateTableAsync<Empleado>();

        }
        #region OPERACIONES
        //CREAR
        public Task<int> EmpleSave(Empleado emple) {
            if (emple.id != 0)
            {
                return dbase.UpdateAsync(emple);
            }
            else {
                return dbase.InsertAsync(emple);
            }
        }
        //LEER
        public Task<List<Empleado>> ObtenerListaEmple()
        {
            return dbase.Table<Empleado>().ToListAsync();
        }
        //LEER 2
        public Task<Empleado> ObtenerEmple(int eid)
        {
            return dbase.Table<Empleado>()
                .Where(i => i.id == eid)
                .FirstOrDefaultAsync();
        }
        //BORRAR
        public Task<int> BorrarEmple(Empleado emple)
        {
            return dbase.DeleteAsync(emple);
        }
        #endregion OPERACIONES
    }
}
