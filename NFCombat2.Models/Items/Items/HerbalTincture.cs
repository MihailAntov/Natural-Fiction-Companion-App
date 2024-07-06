

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class HerbalTincture : Item, ICombatActiveItem, IInventoryActiveItem, IHaveRolls
    {
        public HerbalTincture()
        {
            Name = "TODO";
            IsConsumable = true;
            RollsResult = DiceCalculator.Calculate(2);
        }

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.HerbalTinctureRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
        public bool UnavailableForRestOfCombat { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[1] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var heal = new Heal(RollsResult);
            fight.Effects.Enqueue(heal);
            RollsResult = DiceCalculator.Calculate(2);
            return new List<ICombatResolution>() { heal };
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Health += RollsResult.Dice.Sum(d => d.DiceValue);
            var heal = new Heal(RollsResult);
            RollsResult = DiceCalculator.Calculate(2);
            return heal;
        }
    }
}
