

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
            Init();
        }
        private void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            connection.CreateTableAsync<Settings>();
        }

        public async Task<int> CurrentPlayerId()
        {
            return (await connection.Table<Settings>().FirstOrDefaultAsync()).CurrentPlayerId;
        }

        public async Task UpdateCurrentPlayer(int id)
        {
            var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
            settigns.CurrentPlayerId = id;
            await connection.UpdateAsync(settigns);
        }

        public async Task UpdateLanguage(Language language)
        {
            var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
            settigns.Language = language;
            await connection.UpdateAsync(settigns);
        }
    }
}
