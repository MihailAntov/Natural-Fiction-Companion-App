using NFCombat2.Data.Entities.Combat;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Repositories
{
    public class FightRepository
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

            connection.CreateTable<FightEntity>();
            if(connection.Table<FightEntity>()!= null)
            {
                if(connection.Table<FightEntity>().Count() > 0)
                {

                }
            }

        }
        public FightRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }
    }
}
