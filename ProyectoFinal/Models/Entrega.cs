using System;
using SQLite;

namespace ProyectoFinal.Models
{
    public class Entrega
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public DateTime fecha_entrega { get; set; }
        public DateTime hora_entrega { get; set; }
        public float[] coordenadas { get; set; }
    }
}
