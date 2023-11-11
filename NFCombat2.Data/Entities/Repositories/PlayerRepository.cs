using NFCombat2.Data.Entities.Combat;
using SQLite;
using System;
using System.Reflection.Metadata;

namespace NFCombat2.Data.Entities.Repositories
{
    public class PlayerRepository
    {
        string _dbPath;
        private SQLiteConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;
        private void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteConnection(_dbPath);
            
            connection.CreateTable<PlayerEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                if(connection.Table<PlayerEntity>().Count() > 0) 
                {

                }
            }

        }
        public PlayerRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        public async Task<bool> AddNewProfile(string name)
        {
            int result = 0;
            await Task.Run(() =>
            {
                try
                {
                    Init();

                    // basic validation to ensure a name was entered
                    if (string.IsNullOrEmpty(name))
                        throw new Exception("Valid name required");

                    result = connection.Insert(new PlayerEntity { Name = name });

                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
                }
            });

            return result == 1;
        }

        public List<PlayerEntity> GetAllProfiles()
        {
            Init();
            List<PlayerEntity> profiles = new List<PlayerEntity>();

            try
            {
                profiles = connection.Table<PlayerEntity>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }


            return profiles;
        }
    }
}
