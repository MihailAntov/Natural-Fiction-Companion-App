
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using SQLite;

namespace NFCombat2.Data.Entities.Repositories
{
    public class ItemRepository : Repository<ItemEntity>
    {
        public ItemRepository(string dbPath) : base(dbPath)
        {

        }
    }
}
