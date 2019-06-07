using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class RegistroUsuario : ContentPage
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (validatePasswords())
            {
                lblValidator.Text = "Sus contraseñas si coinciden.";
                lblValidator.TextColor = Color.FromHex("#4F4");
            }
            else
            {
                lblValidator.Text = "Sus contraseñas no coinciden.";
                lblValidator.TextColor = Color.FromHex("#F44");
            }
        }
        bool validatePasswords()
        {
            if (txtPwd.Text == txtPwdConfir.Text)
                return true;
            else
                return false;

        }
        async void onRegistrarUsuario(object sender, EventArgs e)
        {
            /* insertar en base de datos local el usuario */
            //validar que passwords sean correctas

            if (validatePasswords())
            {
                var user = new Credential() { 
                    usuario = txtUser.Text,
                    clave = txtPwd.Text
                };

                // Sign up logic goes here

                var signUpSucceeded = AreDetailsValid(user);

                if (signUpSucceeded){
                    var rootPage = Navigation.NavigationStack.FirstOrDefault();

                    if (rootPage != null)
                    {
                        App.IsUserLoggedIn = true;
                        App.Current.MainPage = new MainPage();
                        
                        //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                       // await Navigation.PopToRootAsync();
                    }
                }
                else{
                    await DisplayAlert("Registro Fallido", "Su usuario o contraseña introducidos no son validos. Modifiquelos usando caracteres o numeros sin dejar espacios en blanco.", "Intentar Nuevamente");

                }
            }
            else{
                await DisplayAlert("Contraseñas no coinciden", "Debe confirmar correctamente su contraseña. Debe ser igual.", "Intentar Nuevamente");

            }
        }
        bool AreDetailsValid(Credential user){
            return (!string.IsNullOrWhiteSpace(user.usuario) && !string.IsNullOrWhiteSpace(user.clave) );
        }

    }
}
