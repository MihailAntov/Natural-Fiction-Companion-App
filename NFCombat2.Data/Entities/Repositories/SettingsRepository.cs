

using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
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
            //_dbPath = dbPath;
            //Init();
            
        }
        //private async Task Init()
        //{
        //    if (connection != null)
        //    {
        //        return;
        //    }
        //    connection = new SQLiteAsyncConnection(_dbPath);
        //    await connection.CreateTableAsync<Settings>();
        //    if(connection.Table<Settings> != null)
        //    {
        //        if (await connection.Table<Settings>().CountAsync() == 0)
        //        {
        //            await connection.InsertAsync(new Settings() { CurrentPlayerId = 0, Language = Language.English });
        //        }
        //    }
        //}

        //public async Task<int> GetCurrentPlayerId()
        //{
        //    await Init();
        //    var settings = await connection.Table<Settings>().FirstOrDefaultAsync();
        //    return settings == null ? 0 : settings.CurrentPlayerId;
        //    //return (await connection.Table<Settings>().FirstOrDefaultAsync()).CurrentPlayerId;
        //}

        //public async Task SetCurrentPlayerId(int id)
        //{
        //    await Init();
        //    var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
        //    settigns.CurrentPlayerId = id;
        //    await connection.UpdateAsync(settigns);
        //}

        //public async Task SetLanguage(Language language)
        //{
        //    await Init();
        //    var settigns = await connection.Table<Settings>().FirstOrDefaultAsync();
        //    settigns.Language = language;
        //    await connection.UpdateAsync(settigns);
        //}

        //public async Task<Language> GetLanguage()
        //{
        //    await Init();
        //    var settings = await connection.Table<Settings>().FirstOrDefaultAsync();
        //    return settings.Language;
        //}
    }
}
