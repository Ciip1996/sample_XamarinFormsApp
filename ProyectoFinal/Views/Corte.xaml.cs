using System;
using System.Collections.Generic;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class Corte : ContentPage
    {
        public Corte()
        {
            InitializeComponent();
        }

        DetalleEntrega_DataBase DetalleEntregaDB = new DetalleEntrega_DataBase(App.detalle_path);
        Entrega_DataBase EntregaDB = new Entrega_DataBase(App.entrega_path);
        Product_DataBase ProductoDB = new Product_DataBase(App.product_path);

        protected async override void OnAppearing()
        {
            var total = 0.0;
            /*List<Entrega> EntregaCollection = new List<Entrega>();
            EntregaCollection = await EntregaDB.GetItemsAsync();
            List<detalle_entrega> Detalle_Entrega_Collection = new List<detalle_entrega>();
            Detalle_Entrega_Collection = await DetalleEntregaDB.GetItemsAsync();*/

            List<Product> ProductoCollection = new List<Product>();
            ProductoCollection = await ProductoDB.GetItemsAsync();

            foreach (Product item in ProductoCollection)
            {
                total += item.precioUnitario * item.cantidad;
            }

            labelCorte.Text = total.ToString();
        }
    }
}
