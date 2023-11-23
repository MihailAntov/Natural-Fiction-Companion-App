

using SQLite;

namespace NFCombat2.Data.Entities.Combat
{
    public class PlayersItemsEntity
    {
        [PrimaryKey]
        public int PlayerId { get; set; }
        [PrimaryKey]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
