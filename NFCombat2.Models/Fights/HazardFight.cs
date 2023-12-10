using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Fights
{
    public class HazardFight : Fight
    {
        public HazardFight(IList<Enemy> enemies) : base(enemies)
        {
        }
    }
}
