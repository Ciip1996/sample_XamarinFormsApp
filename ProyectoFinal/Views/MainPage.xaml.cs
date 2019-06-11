using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Clientes, (NavigationPage)Detail);

        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Clientes:
                        MenuPages.Add(id, new NavigationPage(new Clientes()));
                        break;
                    case (int)MenuItemType.Productos:
                        MenuPages.Add(id, new NavigationPage(new Productos()));
                        break;
                    case (int)MenuItemType.Pedidos:
                        MenuPages.Add(id, new NavigationPage(new Pedidos()));
                        break;
                    case (int)MenuItemType.Corte:
                        MenuPages.Add(id, new NavigationPage(new Corte()));
                        break;
                    case (int)MenuItemType.CerrarSesion:
                        this.OnLogoutButtonClicked(id);
                        break;
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);
                IsPresented = false;
            }
        }
        void OnLogoutButtonClicked(int id)
        {
            App.IsUserLoggedIn = false;
            App.WasUserLoggedOut = true;
            MenuPages.Add(id, new NavigationPage(new Login()));
            //Navigation.InsertPageBefore(new MainPage(), App.Current.NavigationStack);
            //await Navigation.PopToRootAsync();
            /*App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new Login(), this);
            await Navigation.PopAsync();*/
        }
    }
}