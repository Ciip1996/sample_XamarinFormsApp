using System;
using System.Collections.Generic;
using ProyectoFinal.Models;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.Views
{
    public partial class CantidadProducto : ContentPage
    {
        MultiSelectObservableCollection<Product> listaProductos = new MultiSelectObservableCollection<Product>();
        public CantidadProducto(MultiSelectObservableCollection<Product> _list)
        {
            InitializeComponent();
            listaProductos = _list;
            lstCantidad.ItemsSource = listaProductos;
        }

        void btnMenos_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var item = button.CommandParameter as Product;
            var position = listaProductos.IndexOf(item);

            if (listaProductos[position].Data.cantidad - 1 >= 0)
            {
                listaProductos[position].Data.cantidad -= 1;

                lstCantidad.ItemsSource = null;
                lstCantidad.ItemsSource = listaProductos;
            }
        }

        private void btnMas_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var item = button.CommandParameter as Product;
            var position = listaProductos.IndexOf(item);

            listaProductos[position].Data.cantidad += 1;

            lstCantidad.ItemsSource = null;
            lstCantidad.ItemsSource = listaProductos;
        }

        private async void btnAddInfo_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddInfoProducto(listaProductos));
        }
    }
}
