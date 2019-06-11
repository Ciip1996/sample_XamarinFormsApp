using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProyectoFinal.Models;
using ProyectoFinal.Views;

namespace ProyectoFinal.Data
{
    public class ClientsData
    {
        public ObservableCollection<Client> ClientsCollection { get; set; }

        public ClientsData()
        {
            ClientsCollection = new ObservableCollection<Client>(){
                new Client(){
                    Name = "Marco",
                    Email = "marco@gmail.com"
                },
                new Client(){
                    Name = "Ramón",
                    Email = "ramon@cbqasolutions.com"
                },
                new Client(){
                    Name = "Ivan",
                    Email = "ivan@cbqasolutions.com"
                },
                new Client(){
                    Name = "Aviña",
                    Email = "aviña@gmail.com"
                }
            };

        }

    }
}
