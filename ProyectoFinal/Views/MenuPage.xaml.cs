﻿using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            
            if(App.currentUser != null)
            {
                lblProfile.Text = App.currentUser.usuario;
            }

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Inicio" },
                new HomeMenuItem {Id = MenuItemType.Clientes, Title="Clientes" },
                new HomeMenuItem {Id = MenuItemType.Productos, Title="Productos" },
                new HomeMenuItem {Id = MenuItemType.Pedidos, Title="Pedidos" },
                new HomeMenuItem {Id = MenuItemType.Corte, Title="Generar Corte" },
                new HomeMenuItem {Id = MenuItemType.CerrarSesion, Title="Cerrar Sesión" }

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}