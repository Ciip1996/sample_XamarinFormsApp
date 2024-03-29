﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Geolocator;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.Views
{
    public partial class AddInfoProducto : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        Entrega_DataBase entrega_database = new Entrega_DataBase(App.entrega_path);
        DetalleEntrega_DataBase detalle_database = new DetalleEntrega_DataBase(App.detalle_path);
        Product_DataBase producto_bd = new Product_DataBase(App.product_path);

        MultiSelectObservableCollection<Product> listaProductos = new MultiSelectObservableCollection<Product>();

        double lat;
        double lng;

        public AddInfoProducto(MultiSelectObservableCollection<Product> _list)
        {
            InitializeComponent();

            listaProductos = _list;


            MyMap.MapLongClicked += async (sender, e) =>
            {
                lat = e.Point.Latitude;
                lng = e.Point.Longitude;
                
                Geocoder geocoder = new Geocoder();
                string action = "";
                try
                {
                    IEnumerable<string> addressList = await geocoder.GetAddressesForPositionAsync(new Position(lat, lng));
                    string[] s = addressList.ToArray();

                    action = await DisplayActionSheet("Seleccione la dirección más adecuada:", "Cancelar", null, s);

                    foreach (var item in addressList)
                    {

                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }


                Xamarin.Forms.GoogleMaps.Pin pin = new Pin()
                {
                    Type = PinType.Place,
                    Position = new Position(lat, lng),
                    Label = "Direccion de envío.",
                    Address = action
                };

                MyMap.Pins.Add((Xamarin.Forms.GoogleMaps.Pin)pin);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(1.0)));

            };
            
        }

        protected override void OnAppearing()
        {
            ClientsData clients = new ClientsData();
            List<string> nombres = new List<string>();

            foreach(var item in clients.ClientsCollection)
            {
                nombres.Add(item.Name);
            }

            picker.ItemsSource = nombres;
            timepicker_entrega.Time = DateTime.Now.TimeOfDay;
        }

        async void btnGuardar_Clicked(object sender, System.EventArgs e)
        {
            Entrega entrega = new Entrega();
            detalle_entrega detalle = new detalle_entrega();

            entrega.id_cliente = picker.SelectedIndex;
            entrega.fecha_entrega = datepicker_entrega.Date;
            entrega.hora_entrega = timepicker_entrega.Time;
            entrega.comentario = txtComentario.Text;

            entrega.latitud = (float)lat;
            entrega.longitud = (float)lng;

            var id = await entrega_database.SaveItemAsync(entrega);
            double precioTotal = 0.00;


            foreach(var item in listaProductos)
            {
                detalle.id_entrega = id;
                detalle.id_producto = item.Data.id;
                precioTotal += item.Data.precioUnitario;
                await detalle_database.SaveItemAsync(detalle);
            }

            await DisplayAlert("¡Pedido Exitoso!",$" Fecha: {entrega.fecha_entrega}, Hora: {entrega.hora_entrega}, Comentario: {entrega.comentario}, Total:$ {precioTotal}, Coordenadas: {entrega.latitud}, : {entrega.longitud}", "Aceptar");

            _ = this.Navigation.PopToRootAsync();
            await RootPage.NavigateFromMenu((int)MenuItemType.Pedidos);

        }


      /*  public async Task getLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Xamarin.Forms.GoogleMaps.Pin pin = new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(location.Latitude, location.Longitude),
                        Label = "Plaza Mayor",
                        Address = "Boulevard Juan Alonso de Torres Poniente, Valle del Campestre, León, Guanajuato"
                    };

                    MyMap.Pins.Add((Xamarin.Forms.GoogleMaps.Pin)pin);
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1.0)));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                
                throw pEx;
            }
            catch (Exception ex)
            {
                // Unable to get location
                throw ex;
            }
        }*/

        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }
    }
}
