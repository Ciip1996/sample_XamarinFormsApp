using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using SQLite;



namespace ProyectoFinal.Data
{


    public class Login_DataBase
    {
        readonly SQLiteAsyncConnection database;

        public Login_DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Credential>().Wait();
        }

        public Task<Credential> Login(string user, string pwd)
        {
            return database.Table<Credential>().Where(i => (i.usuario == user && i.clave == pwd)).FirstOrDefaultAsync();
        }

        public Task<List<Credential>> GetItemsAsync()
        {
            return database.Table<Credential>().ToListAsync();
        }

        public Task<Credential> GetItemAsync(int id)
        {
            return database.Table<Credential>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Credential item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Credential item)
        {
            return database.DeleteAsync(item);
        }
    }
}
