

using SQLite;

namespace NFCombat2.Data.Entities.Combat
{
    public class PlayersProgramsEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public int PlayerId { get; set; }
        public int ProgramId { get; set; }
    }
}
