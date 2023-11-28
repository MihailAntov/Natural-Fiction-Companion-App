using NFCombat2.Common.Enums;
using SQLite;

namespace NFCombat2.Data.Entities.Programs
{
    public class ProgramEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public ProgramType Type { get; set; }
    }
}
