using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_4.Modelo
{
    public class videorecord
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string uri { get; set; }

        public string descripcion { get; set; }
    }
}
