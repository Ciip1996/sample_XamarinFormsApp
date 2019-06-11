using System;
using System.Collections.Generic;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal.Views
{
    public partial class AddComment : ContentPage
    {
        Entrega_DataBase entrega_database = new Entrega_DataBase(App.entrega_path);
        int id = 0;

        public AddComment(int id_entrega)
        {
            InitializeComponent();
            id = id_entrega;
        }

        async void btnAddComentario_Clicked(object sender, System.EventArgs e)
        {
            Entrega entrega = await entrega_database.GetItemAsync(id);
            entrega.comentario = txtComentario.Text;

            await entrega_database.SaveItemAsync(entrega);
        }
    }
}
