using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Notes
{
    public class NoteEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Text { get; set; }
        public int PlayerID { get; set; }
    }
}
