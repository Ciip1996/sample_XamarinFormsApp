using System;
using System.Collections.ObjectModel;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class ClientViewModel
    {
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients { 
            get { return clients; }
            set {
                clients = value;
            }
        }

        public ClientViewModel() {
            Clients = new ObservableCollection<Client>();
            ClientsData _context = new ClientsData();

            foreach (var client in _context.Clients){
                Clients.Add(client);
            }

        }
    }
}
