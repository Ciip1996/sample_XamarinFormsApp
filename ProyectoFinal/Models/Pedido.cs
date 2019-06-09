using System;
using SQLite;

namespace ProyectoFinal.Models
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public string Id_Pedido { get; set; }
        public string Id_Cliente { get; set; }
        public string pedido_number { get; set; }
        public string fecha_entrega { get; set; }
        public string hora_entrega { get; set; }
        public string Coordenadas { get; set; }
    }
}
