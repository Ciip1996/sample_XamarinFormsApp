using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class Clientes : ContentPage
    {
        public Clientes()
        {
            InitializeComponent();
            BindingContext = new ClientsData();
        }
    }
}
