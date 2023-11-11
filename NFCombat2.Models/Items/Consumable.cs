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

        public int Quantity { get; set; }

        public abstract override IList<ICombatResolution> AddToCombatEffects(Fight fight);

    }
}
