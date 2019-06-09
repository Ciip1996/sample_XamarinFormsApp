using System;
using System.Collections.ObjectModel;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class PedidoViewModel
    {
        public ObservableCollection<Pedido> PedidosCollection { get; set; }


        public PedidoViewModel()
        {
            PedidosCollection = new ObservableCollection<Pedido>()
            { };
            //TODO: Agregar pedidos

        }
    }
}
