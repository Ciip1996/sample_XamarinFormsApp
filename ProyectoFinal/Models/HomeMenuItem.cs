using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Clientes,
        Productos,
        Pedidos,
        Corte,
        CerrarSesion
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
