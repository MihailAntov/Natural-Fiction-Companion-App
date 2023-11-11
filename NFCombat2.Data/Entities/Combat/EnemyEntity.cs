using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFCombat2.Data.Entities.Combat
{
    public class EnemyEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public FightEntity Fight { get; set; } = null!;

        [ForeignKey(nameof(Fight))]
        public int FightId { get; set; }
    }
}
