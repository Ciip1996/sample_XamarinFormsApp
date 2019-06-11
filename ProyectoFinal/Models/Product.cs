using System;
using System.Threading.Tasks;
using SQLite;

namespace ProyectoFinal.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string descripcion { get; set; }
        public float precioUnitario { get; set; }
        public string fotoURL { get; set; }
        public int cantidad { get; set; }

        public static explicit operator double(Product v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Product(Task<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}
