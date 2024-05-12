using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Models.SpecOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory = NFCombat2.Models.Factories.TechniqueFactory;

namespace NFCombat2.Services
{
    class TechniqueService : ITechniqueService
    {
        public List<List<Technique>> UpdateTechniques(Player player)
        {

            var factory = Factory.TechniqueChoices;
            int health = player.Health;
            List<List<Technique>> result = new List<List<Technique>>();
            foreach(var key in factory.Keys)
            {
                if(key <= health)
                {
                    if (player.Techniques[key]!= null)
                    {
                        if (player.Techniques[key] is IModifyPlayer playerModifier)
                        {
                            playerModifier.OnRemoved(player);
                        }
                    }
                    player.Techniques[key] = null;
                }
                else if (player.Techniques[key] == null)
                {
                    result.Add(Factory.TechniqueChoices[key]);
                }
            }

            return result;
        }
    }
}
