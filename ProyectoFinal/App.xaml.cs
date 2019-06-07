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

        public static bool IsUserLoggedIn { get; set; }
        public static bool WasUserLoggedOut { get; set; }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();

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
                    database = new Login_DataBase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

    }
}
