using System;
using SQLite;

namespace ProyectoFinal.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
