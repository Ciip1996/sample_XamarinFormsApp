
using System;
using System.Collections.Generic;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class Pedidos : ContentPage
    {
        Entrega_DataBase dataBase = new Entrega_DataBase(App.entrega_path);
        List<Entrega> ClientsCollection = new List<Entrega>();

        public Pedidos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            ClientsCollection = await dataBase.GetItemsAsync();

            string[] _list = new string[ClientsCollection.Count];
            ClientsData client = new ClientsData();

            for(int i = 0;i < ClientsCollection.Count;i++)
            {
                _list[i] = $"{ClientsCollection[i].id}\t{client.Clients[ClientsCollection[i].id].Name}\t{ClientsCollection[i].fecha_entrega}\t{ClientsCollection[i].estatus}";
            }

            lstEntregas.ItemsSource = null;
            lstEntregas.ItemsSource = _list;
        }

        //async void Item_Tapped(object sender, System.EventArgs e)
        //{
        //    var id_entrega = lstEntregas.SelectedItem.ToString();

        //    //await Navigation.PushAsync(new Mapa());
        //}

        public async void OnMapa(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var id = int.Parse(mi.CommandParameter.ToString()[0].ToString());
            await Navigation.PushAsync(new Mapa(ClientsCollection[id].latitud, ClientsCollection[id].longitud));
        }

        public async void OnOpciones(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var res = await DisplayAlert("¿Entregar?", mi.CommandParameter.ToString(), "OK", "Cancel");

            if (res)
            {
                Console.WriteLine(mi.Id);
                Console.WriteLine(mi.Text);
                Console.WriteLine(mi.CommandParameter.ToString());
            }
        }
    }
}
