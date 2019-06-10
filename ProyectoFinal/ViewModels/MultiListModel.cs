using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoFinal.ViewModels
{
    public class MultiListModel : INotifyPropertyChanged
    {
        public static Product_DataBase dataBase = new Product_DataBase(App.product_path);
        public static MultiSelectObservableCollection<Product> listaFinal = new MultiSelectObservableCollection<Product>();

        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public static MultiSelectObservableCollection<Product> _listProducts = new MultiSelectObservableCollection<Product>();

        public ICommand DisplayNameCommand => new Command<Product>(async product =>
        {
            await Application.Current.MainPage.DisplayAlert("Añadir a la lista?", product.descripcion, "OK", "Cancel");

            listaFinal.Add(product);
        });

        public MultiListModel()
        {

            dataBase.SaveItemAsync(new Product { descripcion = "Tomato", precioUnitario = 20.0f, fotoURL = "https://media.wired.com/photos/59bafdf204afdc5248726f5c/master/w_2400,c_limit/BMW-TA.jpg", cantidad = 0 });

            
            //_listProducts.Add(new Product { descripcion = "Tomato", precioUnitario = 20.0f, fotoURL = "https://media.wired.com/photos/59bafdf204afdc5248726f5c/master/w_2400,c_limit/BMW-TA.jpg", cantidad = 0 });
            //_listProducts.Add(new Product { descripcion = "Romaine Lettuce", precioUnitario = 20.0f, fotoURL = "https://media.wired.com/photos/59bafdf204afdc5248726f5c/master/w_2400,c_limit/BMW-TA.jpg", cantidad = 0 });
            //_listProducts.Add(new Product { descripcion = "Zucchini", precioUnitario = 100.0f, fotoURL = "https://media.wired.com/photos/59bafdf204afdc5248726f5c/master/w_2400,c_limit/BMW-TA.jpg", cantidad = 0 });
            //lstView.ItemsSource = veggies;
        }
    }
}
