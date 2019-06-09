using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using SQLite;

namespace ProyectoFinal.Data
{
    public class Product_DataBase
    {
        readonly SQLiteAsyncConnection database;

        public Product_DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> GetItemsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        //public Task<List<Product>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Done] = 0");
        //}

        public Task<Product> GetItemAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Product item)
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

        public Task<int> DeleteItemAsync(Product item)
        {
            return database.DeleteAsync(item);
        }
    }
}
