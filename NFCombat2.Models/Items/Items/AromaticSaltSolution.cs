

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class AromaticSaltSolution : Item, ICombatActiveItem, IInventoryActiveItem
    {
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
            return resolutions;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            throw new NotImplementedException();
        }
    }
}
