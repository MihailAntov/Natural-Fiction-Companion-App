

using NFCombat2.Common.Enums;
using SQLite;

namespace NFCombat2.Data.Entities.Combat
{
    public class PlayersEquipmentsEntity
    {
        public int PlayerId { get; set; }
        public int EquipmentId { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public AttachedTo AttachedTo { get; set; } = AttachedTo.None;
        public bool IsConsumable { get; set; } = false;
        public int Quantity { get; set; }
    }
}
