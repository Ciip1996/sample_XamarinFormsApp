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

        protected override async void OnAppearing()
        {
            List<Product> _list = await MultiListModel.dataBase.GetItemsAsync();
            foreach(var item in _list)
            {
                MultiListModel._listProducts.Add(item);
            }

            lstView.ItemsSource = MultiListModel._listProducts;
        }

        private async void btnSiguiente_Clicked(object sender, System.EventArgs e)
        {
            lista = MultiListModel.listaFinal;
            await Navigation.PushAsync(new CantidadProducto(lista));
        }
    }
}
