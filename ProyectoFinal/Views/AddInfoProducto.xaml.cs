using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.Views
{
    public partial class AddInfoProducto : ContentPage
    {
        Entrega_DataBase entrega_database = new Entrega_DataBase(App.entrega_path);
        DetalleEntrega_DataBase detalle_database = new DetalleEntrega_DataBase(App.detalle_path);

        MultiSelectObservableCollection<Product> listaProductos = new MultiSelectObservableCollection<Product>();
        public AddInfoProducto(MultiSelectObservableCollection<Product> _list)
        {
            InitializeComponent();

            listaProductos = _list;

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(21.1576191, -101.6975641), Distance.FromMiles(1)));
            getLocationAsync();
            
        }

        async void btnGuardar_Clicked(object sender, System.EventArgs e)
        {
            Entrega entrega = new Entrega();
            detalle_entrega detalle = new detalle_entrega();

            entrega.id_cliente = picker.SelectedIndex;
            entrega.fecha_entrega = datepicker_entrega.Date;
            entrega.hora_entrega = timepicker_entrega.Time;
            entrega.comentario = txtComentario.Text;
            entrega.latitud = 10.0f;
            entrega.longitud = 13.0f;

            var id = await entrega_database.SaveItemAsync(entrega);

            foreach(var item in listaProductos)
            {
                detalle.id_entrega = id;
                detalle.id_producto = item.Data.id;
            }

            await detalle_database.SaveItemAsync(detalle);

            Console.WriteLine($"Id: {entrega.id_cliente}, Fecha: {entrega.fecha_entrega}, Hora: {entrega.hora_entrega}, Comentario: {entrega.comentario}, Coordenadas: {entrega.latitud}, {entrega.longitud}");
            Console.WriteLine($"Id Entrega: {detalle.id_entrega}, Id Producto: {detalle.id_producto}");
        }

        public async Task getLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Xamarin.Forms.Maps.Pin pin = new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(location.Latitude, location.Longitude),
                        Label = "Plaza Mayor",
                        Address = "Boulevard Juan Alonso de Torres Poniente, Valle del Campestre, León, Guanajuato",
                        Id = "Xamarin"
                    };

                    MyMap.Pins.Add((Xamarin.Forms.Maps.Pin)pin);
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
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }
    }
}
