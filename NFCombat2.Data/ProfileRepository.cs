

using NFCombat2.Data.Models;
using NFCombat2.Data.Models.Items;
using SQLite;
using System;
using System.Reflection.Metadata;

namespace NFCombat2.Data
{
    public class ProfileRepository
    {
        string _dbPath;
        private SQLiteConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;
        private void Init()
        {
            if(connection != null)
            {
                return;
            }
            connection = new SQLiteConnection(_dbPath);
            
            connection.CreateTable<Profile>();
            
        }
        public ProfileRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();    
        }

        public async Task<bool> AddNewProfile(string name)
        {
            int result = 0;
            await Task.Run(() => {
                try
                {
                    Init();

                    // basic validation to ensure a name was entered
                    if (string.IsNullOrEmpty(name))
                        throw new Exception("Valid name required");

                    result = connection.Insert(new Profile { Name = name });

                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
                }
            });
            
            return result == 1;
        }

        public List<Profile> GetAllProfiles()
        {
            Init();
            List<Profile> profiles = new List<Profile>();
            
                try
                {
                    profiles = connection.Table<Profile>().ToList();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                }
           

            return profiles;
        }
    }
}
