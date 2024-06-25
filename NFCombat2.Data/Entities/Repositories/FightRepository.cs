using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Data.Extensions.FightRepositorySeeder;
using NFCombat2.Models.Items.Weapons;
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
        public FightRepository()
        {
            
        }

        public Fight? GetFight(int episodeNumber)
        {
            if (Fights.ContainsKey(episodeNumber))
            {
                var creatorFunc = Fights[episodeNumber];
                return creatorFunc();
            }
            return null;
            
        }
        
    }
}
