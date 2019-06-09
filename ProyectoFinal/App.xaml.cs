using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.Services;
using ProyectoFinal.Views;
using ProyectoFinal.Data;
using System.IO;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        // Add instances for local databases here 
        static Login_DataBase database;
        public static string path { get; set; }
        public static bool IsUserLoggedIn { get; set; }
        public static bool WasUserLoggedOut { get; set; }

        static Product_DataBase product_database;
        static Entrega_DataBase entrega_database;
        static DetalleEntrega_DataBase detalle_database;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();

            //SQLite Login
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LoginSQLite.db3");
            MainPage = new MainPage();
            WasUserLoggedOut = false;

            if (!IsUserLoggedIn)
            {
                Current.MainPage = new NavigationPage(new Login());
            }


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static Login_DataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new Login_DataBase(path);
                }
                return database;
            }
        }

        //BASE DE DATOS DE PRODUCTO
        public static Product_DataBase DataBase
        {
            get
            {
                if (product_database == null)
                {
                    product_database = new Product_DataBase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductSQLite.db3"));
                }
                return product_database;
            }
        }

        //BASE DE DATOS DE PRODUCTO
        public static Entrega_DataBase DataBase
        {
            get
            {
                if (entrega_database == null)
                {
                    entrega_database = new Entrega_DataBase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EntregaSQLite.db3"));
                }
                return entrega_database;
            }
        }

        //BASE DE DATOS DE PRODUCTO
        public static DetalleEntrega_DataBase DataBase
        {
            get
            {
                if (detalle_database == null)
                {
                    detalle_database = new DetalleEntrega_DataBase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DetalleEntregaSQLite.db3"));
                }
                return detalle_database;
            }
        }

    }
}
