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

        public DataBase(String dbpath,String table) {
            dbase = new SQLiteAsyncConnection(dbpath);
            if (table.Equals("Empleado")) { dbase.CreateTableAsync<Empleado>(); }
            else if (table.Equals("Contactos")) { dbase.CreateTableAsync<Contactos>(); }
        }
        #region OPERACIONES_EMPLEADOS
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
        #endregion OPERACIONES_EMPLEADOS
        #region OPERACIONES_CONTACTOS
        //CREAR
        public Task<int> ContactSave(Contactos contac)
        {
            if (contac.id != 0)
            {
                return dbase.UpdateAsync(contac);
            }
            else
            {
                return dbase.InsertAsync(contac);
            }
        }
        //LEER
        public Task<List<Contactos>> ObtenerListaContactos()
        {
            return dbase.Table<Contactos>().ToListAsync();
        }
        //LEER 2
        public Task<Contactos> ObtenerContacto(int eid)
        {
            return dbase.Table<Contactos>()
                .Where(i => i.id == eid)
                .FirstOrDefaultAsync();
        }
        //BORRAR
        public Task<int> BorrarEmple(Contactos contac)
        {
            return dbase.DeleteAsync(contac);
        }
        #endregion OPERACIONES_CONTACTOS
    }
}
