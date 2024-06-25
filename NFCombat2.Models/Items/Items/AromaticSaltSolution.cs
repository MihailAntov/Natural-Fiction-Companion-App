

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class AromaticSaltSolution : Item, ICombatActiveItem, IInventoryActiveItem
    {
        private int _reduceAmount = 2;
        private int _increaseMaxAmount = 1;
        public AromaticSaltSolution()
        {
            Name = "TODO";
            IsConsumable = true;
        }

        public bool UnavailableForRestOfCombat { get; set; } = false;

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            List<ICombatResolution> resolutions = new List<ICombatResolution>()
            {
                new OverloadDecrease(fight.Player, 2),
                new MaxOverloadIncrease(fight.Player, 1)
            };

            foreach(var  resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {

            player.MaxOverload += _increaseMaxAmount;
            player.Overload -= _reduceAmount;
            return new MaxOverloadIncrease(player, _increaseMaxAmount);
        }
    }
}
