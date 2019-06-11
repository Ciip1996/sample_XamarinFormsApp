﻿
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
        List<string> _list;

        string condition = "";

        public Pedidos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            fillList(condition);
        }

        public async void fillList(string condition)
        {
            ClientsCollection = await dataBase.GetItemsAsync();

            _list = new List<string>(); ;
            ClientsData client = new ClientsData();

            for (int i = 0; i < ClientsCollection.Count; i++)
            {
                string datos = $"{ClientsCollection[i].id}\t{client.Clients[ClientsCollection[i].id].Name}\t{ClientsCollection[i].fecha_entrega}\t{ClientsCollection[i].estatus}";

                if(condition == "Entregado" && datos.Substring(datos.LastIndexOf('\t') + 1) == "True")
                {
                    _list.Add(datos);
                }
                else if (condition == "No entregado" && datos.Substring(datos.LastIndexOf('\t') + 1) == "False")
                {
                    _list.Add(datos);
                }
                else
                {
                    _list.Add(datos);
                }
            }

            lstEntregas.ItemsSource = null;
            lstEntregas.ItemsSource = _list;
        }

        void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (picker_estatus.SelectedItem.ToString())
            {
                case "Entregado":
                    condition = "Entregado";
                    fillList(condition);
                    break;
                case "No entregado":
                    condition = "No entregado";
                    fillList(condition);
                    break;
                case "Todos":
                    condition = "";
                    fillList(condition);
                    break;
                default: Console.WriteLine("ERROR en el picker");
                    break;
            }
        }

        //async void Item_Tapped(object sender, System.EventArgs e)
        //{
        //    var id_entrega = lstEntregas.SelectedItem.ToString();

        //    //await Navigation.PushAsync(new Mapa());
        //}

        public async void OnMapa(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            string datos = mi.CommandParameter.ToString();


            Console.WriteLine(getId(datos));
            var id = getId(datos);
            await Navigation.PushAsync(new Mapa(ClientsCollection[id - 1].latitud, ClientsCollection[id - 1].longitud));
        }

        public async void OnOpciones(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            string datos = mi.CommandParameter.ToString();

            string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Comentario", "Cobrar", "Entregar");

            switch (action)
            {
                case "Comentario":
                    comentarioPedido(getId(datos));
                    break;
                case "Cobrar": 
                    break;
                case "Entregar":
                    entregarPedido(getId(datos));
                    break;
                default: Console.WriteLine("Error");
                    break;
            }
        }

        public int getId(string valor)
        {
            int charLocation = valor.IndexOf("\t", StringComparison.Ordinal);

            if (charLocation > 0)
            {
                string result = valor.Substring(0, charLocation);
                return int.Parse(result);
            }

            return 0;
        }

        public async void comentarioPedido(int id)
        {
            Entrega entrega = await dataBase.GetItemAsync(id);

            var res = await DisplayAlert("Comentario del pedido", entrega.comentario, "Añadir comentario", "Cancel");

            if (res)
            {
                await Navigation.PushAsync(new AddComment(id));
            }
        }

        public void cobrarPedido()
        {
            DisplayAlert("Comentario del pedido","100", "Añadir comentario", "Cancel")
        }

        public async void entregarPedido(int id)
        {
            Entrega entrega = await dataBase.GetItemAsync(id);
            entrega.estatus = true;

            await dataBase.SaveItemAsync(entrega);

            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("¡Pedido entregado!", "Tu pedido fue entregado", 1);
            //ClientsCollection.Insert(id - 1, entrega);

            fillList(condition);
        }
    }
}
