

using NFCombat2.Common.Enums;
using SQLite;

namespace NFCombat2.Data.Entities
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Language Language { get; set; } = Language.English;
        public int CurrentPlayerId { get; set; } = 0;

    }
}
