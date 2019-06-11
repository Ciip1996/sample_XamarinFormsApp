using System;
using System.Collections.ObjectModel;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModels
{
    public class ClientsViewModel
    {
        public ObservableCollection<Client> ClientsCollection { get; set; }

        public ClientsViewModel()
        {
                ClientsCollection = new ObservableCollection<Client>()
                {
                    new Client() { Name="Ramon Manrique", Email="ramon.manfig@gmail.com"},
                    new Client() { Name="Carlos Aviña", Email="aviña@gmail.com"}
                };
        }


    }
}
