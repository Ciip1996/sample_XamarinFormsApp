using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using SQLite;

namespace ProyectoFinal.Data
{
    public class Entrega_DataBase
    {
        readonly SQLiteAsyncConnection database;

        public Entrega_DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Entrega>().Wait();
        }

        public Task<List<Entrega>> GetItemsAsync()
        {
            return database.Table<Entrega>().ToListAsync();
        }

        //public Task<List<Entrega>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<Entrega>("SELECT * FROM [Entrega] WHERE [Done] = 0");
        //}

        public Task<Entrega> GetItemAsync(int id)
        {
            return database.Table<Entrega>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Entrega item)
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

        public Task<int> DeleteItemAsync(Entrega item)
        {
            return database.DeleteAsync(item);
        }
    }
}
