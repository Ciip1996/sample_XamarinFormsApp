using System;
using SQLite;

namespace ProyectoFinal.Models
{
    public class detalle_entrega
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int id_entrega { get; set; }
        public int id_producto { get; set; }
    }
}
