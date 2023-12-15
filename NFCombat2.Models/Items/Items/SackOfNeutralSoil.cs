

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class SackOfNeutralSoil : Item, ICombatActiveItem, IInventoryActiveItem
    {
        public SackOfNeutralSoil()
        {
            Name = "TODO";
            IsConsumable = true;
        }

        public bool UnavailableForRestOfCombat { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[1] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var reduceIonization = new IonizationDecrease(fight.Player, 1);
            fight.Effects.Enqueue(reduceIonization);
            return new List<ICombatResolution>() { reduceIonization };
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Ionization--;
            return new IonizationDecrease(player, 1);
        }
    }
}
