﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace ProyectoFinal.Views
{
    public partial class Mapa : ContentPage
    {
        public Mapa(double latitud, double longitud)
        {
            InitializeComponent();
            MapaEntrega.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitud, longitud), Distance.FromMiles(1)));

            Pin pin = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(latitud, longitud),
                Label = "Locación de pedido"
            };

            MapaEntrega.Pins.Add((Xamarin.Forms.GoogleMaps.Pin)pin);
        }
    }
}
