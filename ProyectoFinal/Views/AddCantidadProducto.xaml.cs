using System;
using System.Collections.Generic;
using ProyectoFinal.Models;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.Views
{
    public partial class AddCantidadProducto : ContentPage
    {
        MultiSelectObservableCollection<Product> listaProductos = new MultiSelectObservableCollection<Product>();
        public AddCantidadProducto(MultiSelectObservableCollection<Product> _list)
        {
            InitializeComponent();
            listaProductos = _list;
        }

        private void btnMas_Clicked(object sender, System.EventArgs e)
        {
            //Button button = sender as Button;
            //int index = listaProductos.IndexOf(button);

            Console.WriteLine("0");
        }

        void btnMenos_Clicked(object sender, System.EventArgs e)
        {
            //if(cantidad - 1 >= 0)
            //{
            //    cantidad--;
            //    //txtCant.Text = cantidad.ToString();
            //}
            Console.WriteLine("0");
        }

        private async void btnAddInfo_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddInfoProducto());
        }
    }
}
