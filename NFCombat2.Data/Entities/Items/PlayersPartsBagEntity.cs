

using SQLite;

namespace NFCombat2.Data.Entities.Items
{
    public class PlayersPartsBagEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int PartsBagId { get; set; }
    }
}
