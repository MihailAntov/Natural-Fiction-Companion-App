
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Extensions;
using SQLite;
using NFCombat2.Models.Items;
using AutoMapper;

namespace NFCombat2.Data.Entities.Repositories
{
    public class ItemRepository 
    {
        string _dbPath;
        private IMapper _mapper;
        protected SQLiteAsyncConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;

        public ItemRepository(string dbPath, IMapper mapper)
        {
            _dbPath = dbPath;
            _mapper = mapper;
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

        

        public async Task InsertRange<ItemEntity>(IEnumerable<ItemEntity> items)
        {
            Init();
            await connection.InsertAllAsync(items);
        }

        public async Task<int> DeleteAll()
        {
            Init();
            return await connection.DropTableAsync<ItemEntity>();

        }
        public async Task<ItemEntity> Get(int id)
        {
            Init();
            return await connection.GetAsync<ItemEntity>(id);
        }

        public async Task<IEnumerable<ItemEntity>> GetCategory(ItemCategory category)
        {
            Init();
            return await connection
                .Table<ItemEntity>()
                .Where(i => i.Category == category)
                .ToListAsync();

        }

        public async Task<ICollection<ItemEntity>> GetAll()
        {
            Init();
            return await connection.Table<ItemEntity>().ToListAsync();
        }

    }
}
