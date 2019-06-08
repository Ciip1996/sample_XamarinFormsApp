using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProyectoFinal.Views
{
    public partial class AddInfoProducto : ContentPage
    {
        public AddInfoProducto()
        {
            InitializeComponent();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(21.1576191, -101.6975641), Distance.FromMiles(1)));

            getLocationAsync();
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
