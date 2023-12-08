

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class SelfRepairFoam : Item, IInventoryActiveItem
    {
        public SelfRepairFoam()
        {
            Name = "Self Repair Foam";
            IsConsumable = true;
        }
        public string[] MessageArgs => throw new NotImplementedException();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            throw new NotImplementedException();
        }
    }
}
