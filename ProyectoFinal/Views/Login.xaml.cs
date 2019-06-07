using System;
using System.Collections.Generic;
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

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
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

        bool AreCredentialsCorrect(Credential user)
        {
            return user.usuario == Constants.Username && user.clave == Constants.Password;
        }

    }
}
