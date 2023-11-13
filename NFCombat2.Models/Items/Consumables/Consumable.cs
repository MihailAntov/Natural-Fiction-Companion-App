using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Consumables
{
    public abstract class Consumable : CombatItem
    {
        public Consumable()
        {

        }

        public abstract override IList<ICombatResolution> AddToCombatEffects(Fight fight);

    }
}
