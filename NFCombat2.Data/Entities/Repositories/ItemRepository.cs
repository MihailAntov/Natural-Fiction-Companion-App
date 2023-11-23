
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

        

        

    }
}
