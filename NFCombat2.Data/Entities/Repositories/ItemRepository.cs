
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Extensions;
using SQLite;
using NFCombat2.Models.Items;

namespace NFCombat2.Data.Entities.Repositories
{
    public class ItemRepository 
    {
        string _dbPath;
        protected SQLiteAsyncConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;

        public ItemRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }
        private async void Init()
        {
            if (connection != null)
            {
                await connection.CreateTableAsync<ItemEntity>();
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<ItemEntity>();

        }

        

        

    }
}
