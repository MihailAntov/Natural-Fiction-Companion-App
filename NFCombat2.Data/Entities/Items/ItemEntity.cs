
using NFCombat2.Data.Enums;
using SQLite;

namespace NFCombat2.Data.Entities.Items
{
    public class ItemEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ItemType Type { get; set; }
        public ItemCategory Category { get; set; }
    }
}
