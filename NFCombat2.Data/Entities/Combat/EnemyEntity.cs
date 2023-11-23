using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFCombat2.Data.Entities.Combat
{
    public class EnemyEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FightId { get; set; } 
    }
}
