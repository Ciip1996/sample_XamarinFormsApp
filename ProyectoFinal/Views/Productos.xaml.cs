using System;
using System.Collections.Generic;
using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.Views
{
    public partial class Productos : ContentPage
    {
        MultiSelectObservableCollection<Product> lista = new MultiSelectObservableCollection<Product>();
        public Productos()
        {
            InitializeComponent();

            this.BindingContext = new MultiListModel();
        }

        private async void btnSiguiente_Clicked(object sender, System.EventArgs e)
        {
            lista = MultiListModel.listaFinal;
            await Navigation.PushAsync(new CantidadProducto(lista));
        }
    }
}
