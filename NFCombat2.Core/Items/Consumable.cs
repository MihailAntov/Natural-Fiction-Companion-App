using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items
{
    public abstract class Consumable : Item
    {
        public Consumable()
        {
            
        }
        
        public override string Description { get; set; }

        public abstract override IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight);

    }
}
