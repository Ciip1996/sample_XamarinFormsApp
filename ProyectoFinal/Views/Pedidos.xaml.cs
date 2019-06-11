
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
        public Pedidos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            List<Entrega> ClientsCollection = new List<Entrega>();

            ClientsCollection = await dataBase.GetItemsAsync();
            lstEntregas.ItemsSource = ClientsCollection;
        }
    }
}
