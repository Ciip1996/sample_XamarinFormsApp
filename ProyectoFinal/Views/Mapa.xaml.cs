using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProyectoFinal.Views
{
    public partial class Mapa : ContentPage
    {
        public Mapa(double latitud, double longitud)
        {
            InitializeComponent();
            MapaEntrega.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitud, longitud), Distance.FromMiles(1)));
        }
    }
}
