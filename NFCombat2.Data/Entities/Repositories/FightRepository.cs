using NFCombat2.Data.Entities.Combat;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Repositories
{
    public class FightRepository : Repository<FightEntity>
    {
        public FightRepository(string dbPath) : base(dbPath)
        {
        }
    }
}
