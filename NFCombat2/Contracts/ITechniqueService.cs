using NFCombat2.Models.Player;
using NFCombat2.Models.SpecOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Contracts
{
    public interface ITechniqueService
    {
        List<List<Technique>> UpdateTechniques(Player player);
        
    }
}
