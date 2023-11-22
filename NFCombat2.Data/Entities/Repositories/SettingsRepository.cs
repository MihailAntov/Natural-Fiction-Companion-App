

using NFCombat2.Common.Enums;
using SQLite;

namespace NFCombat2.Data.Entities.Repositories
{
    public class SettingsRepository 
    {
        string _dbPath;
        protected SQLiteAsyncConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;

        public SettingsRepository(string dbPath)
        {
            _dbPath = dbPath;
            
        }
        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Settings>();
            if(await (connection.Table<Settings>().CountAsync()) == 0)
            {
               await connection.InsertAsync(new Settings() { CurrentPlayerId = 0, Language = Language.English });

            }
            
        }

        public async Task<int> CurrentPlayerId()
        {
            await Init();
            return (await connection.Table<Settings>().FirstOrDefaultAsync()).CurrentPlayerId;
        }

        public async Task UpdateCurrentPlayer(int id)
        {
            await Init();
            var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
            settigns.CurrentPlayerId = id;
            await connection.UpdateAsync(settigns);
        }

        public async Task UpdateLanguage(Language language)
        {
            await Init();
            var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
            settigns.Language = language;
            await connection.UpdateAsync(settigns);
        }
    }
}
