
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Enums;
using NFCombat2.Data.Extensions;
using SQLite;

namespace NFCombat2.Data.Entities.Repositories
{
    public class ItemRepository : Repository<ItemEntity>
    {
        public ItemRepository(string dbPath) : base(dbPath)
        {
            
        }

        public async Task<IList<ItemEntity>> GetCategory(ItemCategory category)
        {
            return await connection.Table<ItemEntity>().Where(i=> i.Category == category).ToListAsync();
        }

    }
}
