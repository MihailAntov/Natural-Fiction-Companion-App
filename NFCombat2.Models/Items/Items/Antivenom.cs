

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
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

        public bool UnavailableForRestOfCombat { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[1] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            
            var reducePathogens = new PathogenDecrease(fight.Player, 1);
            fight.Effects.Enqueue(reducePathogens);
            return new List<ICombatResolution>() { reducePathogens };
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Pathogens--;
            return new PathogenDecrease(player, 1);
            
        }
    }
}
