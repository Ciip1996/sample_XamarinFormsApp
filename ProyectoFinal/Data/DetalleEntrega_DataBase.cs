using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using SQLite;

namespace ProyectoFinal.Data
{
    public class DetalleEntrega_DataBase
    {
        readonly SQLiteAsyncConnection database;

        public DetalleEntrega_DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<detalle_entrega>().Wait();
        }

        public Task<List<detalle_entrega>> GetItemsAsync()
        {
            return database.Table<detalle_entrega>().ToListAsync();
        }

        //public Task<List<detalle_entrega>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<detalle_entrega>("SELECT * FROM [detalle_entrega] WHERE [Done] = 0");
        //}

        public Task<detalle_entrega> GetItemAsync(int id)
        {
            return database.Table<detalle_entrega>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(detalle_entrega item)
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

        public Task<int> DeleteItemAsync(detalle_entrega item)
        {
            return database.DeleteAsync(item);
        }
    }
}
