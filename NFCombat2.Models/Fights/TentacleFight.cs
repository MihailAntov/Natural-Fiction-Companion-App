using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Fights
{
    public class TentacleFight : Fight
    {
        public TentacleFight(IList<Enemy> enemies) : base(enemies)
        {
        }

        public bool ProtectedFromMaser { get; set; }
        
        
    }
}
