

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Antivenom : Item, ICombatActiveItem, IInventoryActiveItem
    {
        public Antivenom()
        {
            Name = "Antivenom";
            IsConsumable = true;
            Quantity = 1;
        }

        public bool UnavailableForRestOfCombat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MessageType MessageType => throw new NotImplementedException();

        public string[] MessageArgs => throw new NotImplementedException();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            Quantity--;
            if (Quantity == 0)
            {
                fight.Player.Items.Remove(this);
                fight.Player.ExtraItems.Remove(this);
            }
            throw new NotImplementedException();
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            Quantity--;
            if (Quantity == 0)
            {
                player.Items.Remove(this);
                player.ExtraItems.Remove(this);
            }

            throw new NotImplementedException();
        }
    }
}
