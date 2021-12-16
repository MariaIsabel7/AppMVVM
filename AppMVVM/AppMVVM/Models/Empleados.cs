using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMVVM.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(70)]
        public String nombre { get; set; }

        [MaxLength(70)]
        public String apellido { get; set; }

        public int edad { get; set; }

        [MaxLength(100)]
        public String direccion { get; set; }

        [MaxLength(100)]
        public String puesto { get; set; }

    }
}
