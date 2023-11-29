
using NFCombat2.Common.Enums;
using SQLite;

namespace NFCombat2.Data.Entities.Items
{
    public class ItemEntity
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        
        public ItemType Type { get; set; }
        public ItemCategory Category { get; set; }
        public bool IsCraftOnly { get; set; }        
    }
}
