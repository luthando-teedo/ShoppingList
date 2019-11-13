using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TshirtList
{
    public class functionalityClass
    {
        readonly SQLiteAsyncConnection database;

        public functionalityClass(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ClassProperties>().Wait();
        }

        public Task<int> SaveItemAsync(ClassProperties Properties)
        {
            if (Properties.ID != 0)
            {
                return database.UpdateAsync(Properties);
            }
            else
            {
                return database.InsertAsync(Properties);
            }
        }

        public Task<List<ClassProperties>> GetItemsAsync()
        {
            return database.Table<ClassProperties>().ToListAsync();
        }
       
        public Task<int> DeleteItemAsync(ClassProperties item)
        {
            return database.DeleteAsync(item);
        }
    }
}
