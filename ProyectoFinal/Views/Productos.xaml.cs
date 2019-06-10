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

            if(_list.Count == 0)
            {
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Airpods", precioUnitario = 3599.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/airpods.jpeg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Santa Cruz Blue", precioUnitario = 86532.41f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/bike.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Gorra", precioUnitario = 299.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/cap.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "GoPro", precioUnitario = 7199.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/gopro.jpeg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "iMac", precioUnitario = 26999.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/imac.jpeg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "iPhone X", precioUnitario = 11500.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/iphone.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Nintendo Switch", precioUnitario = 6599.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/nintendoswitch.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Solid State Drive Samsung", precioUnitario = 1818.99f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/solid.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Pinta Inglesa", precioUnitario = 41.76f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/vaso.jpg", cantidad = 1 });
                await MultiListModel.dataBase.SaveItemAsync(new Product { descripcion = "Xbox One X", precioUnitario = 9979.0f, fotoURL = "https://imagenes-xamarin.s3.us-east-2.amazonaws.com/imagenes/xbos.jpeg", cantidad = 1 });
            }

            _list = await MultiListModel.dataBase.GetItemsAsync();

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
