using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Wrench : Item, IInventoryActiveItem
    {
        public Wrench()
        {
            Name = "Wrench";
            IsConsumable = true;
        }

        public void AffectPlayer(Player.Player player)
        {
            throw new NotImplementedException();
        }
    }
}
