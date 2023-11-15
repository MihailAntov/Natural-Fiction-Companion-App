using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Repositories
{
    public abstract class Repository<T> where T : new()
    {
        string _dbPath;
        protected SQLiteAsyncConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;

        public Repository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }
        private void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
        }

        public async Task Insert(T item)
        {
          await connection.InsertAsync(item);
        }

        public async Task InsertRange(IEnumerable<T> items)
        {
            await connection.InsertAllAsync(items);
        }

        public async Task<int> DeleteAll()
        {
            return await connection.DeleteAllAsync<T>();
        }

        public async Task Update(T item)
        {
            await connection.UpdateAsync(item);
        }

        public async Task<T> Get(int id)
        {
            return await connection.GetAsync<T>(id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await connection.Table<T>().ToListAsync();
        }

    }
}
