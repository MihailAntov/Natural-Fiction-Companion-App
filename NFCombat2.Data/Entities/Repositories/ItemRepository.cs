
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using SQLite;

namespace NFCombat2.Data.Entities.Repositories
{
    public class ItemRepository
    {
        string _dbPath;
        private SQLiteConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;
        private void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteConnection(_dbPath);

            connection.CreateTable<ItemEntity>();

        }
        public ItemRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }
    }
}
