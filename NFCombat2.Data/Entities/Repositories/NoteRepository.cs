

using AutoMapper;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Notes;
using NFCombat2.Data.Entities.Programs;
using NFCombat2.Data.Extensions;
using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using SQLite;

namespace NFCombat2.Data.Entities.Repositories
{
    public class NoteRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; } = string.Empty;

        private SQLiteAsyncConnection connection = null!;

        public NoteRepository(string dbPath, IMapper mapper)
        {
            _dbPath = dbPath;
            Init();

        }

        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);

            await connection.CreateTableAsync<NoteEntity>();            
        }

        


    }
}
