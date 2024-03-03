

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

        public async Task<int> AddNewNote(string title, Player player)
        {
            int result = 0;
            await Init();
            await Task.Run(async () =>
            {
                try
                {


                    // basic validation to ensure a name was entered
                    if (string.IsNullOrEmpty(title))
                        throw new Exception("Valid title required");


                    result = await connection.InsertAsync(new NoteEntity { Title = title, PlayerID = player.Id });

                    StatusMessage = string.Format("{0} record(s) added (Title: {1})", result, title);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", title, ex.Message);
                }
            });

            return result;
        }


        private async Task UpdateEntity(Note note, Player player)
        {
            await Init();

            var entity = await connection.GetAsync<NoteEntity>(note.Id);
            entity.Text = note.Text;    
            await connection.UpdateAsync(entity);
        }

        private async Task DeleteEntity(Note note)
        {

            await Init();
            await connection.DeleteAsync<NoteEntity>(note.Id);
        }


    }
}
