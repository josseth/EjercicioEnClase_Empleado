using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PROEHECT.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string edad { get; set; }
        public string genero { get; set; }
        public string fechaingreso { get; set; }

    }
}
