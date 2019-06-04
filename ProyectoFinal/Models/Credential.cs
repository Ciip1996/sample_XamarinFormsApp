using System;
using SQLite;


namespace ProyectoFinal.Models
{
    public class Credential
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
    }
}
