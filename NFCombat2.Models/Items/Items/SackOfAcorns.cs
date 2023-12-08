

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class SackOfAcorns : Item, IInventoryActiveItem
    {
        public SackOfAcorns()
        {
            Name = "Sack of Acorns";
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
