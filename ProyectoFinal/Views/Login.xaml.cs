using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.WasUserLoggedOut)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Credential
            {
                usuario = txtUser.Text,
                clave = txtPwd.Text
            };

            bool isvalid = false;

            var credential = new Credential();
            var database = new Login_DataBase(App.path);

            try
            {
                App.currentUser = await database.Login(user.usuario, user.clave);
                _ = (App.currentUser != null) ? (isvalid = true) : (isvalid = false);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ocurrió Excepcion", "Ocurrió la siguiente exepción: " + ex.Message, "Entendido");
                isvalid = false;
                throw ex;
            }


            if (isvalid)
            {
                activityIndicator.Opacity = 0;
                activityIndicator.IsEnabled = true;
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;

                await img.ScaleTo(0.5, 400);
                await activityIndicator.FadeTo(1, 150);

                //img.IsVisible = false;
                await Task.Delay(100);
                App.IsUserLoggedIn = true;
                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
                App.Current.MainPage = new MainPage();
            }
            else
            {
                await DisplayAlert("Inicio de Sesión Fallido", "Su usuario o contraseña no coinciden, porfavor intente nuevamente.", "Intentar Nuevamente");
                txtUser.Text = string.Empty;
                txtPwd.Text = string.Empty;
            }
        }

    }
}
