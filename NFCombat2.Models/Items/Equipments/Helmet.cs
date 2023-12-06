

using NFCombat2.Models.Actions;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class Helmet : Equipment, IModifyResolution
    {
        public Helmet()
        {
            Name = "Helmet";
            Description = "Prevents critical damage.";
        }

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is EnemyCrit crit)
            {
                crit.CritMultiplier = 1;
            }
            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
