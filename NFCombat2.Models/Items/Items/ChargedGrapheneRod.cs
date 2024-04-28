

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class ChargedGrapheneRod : Item, ICombatActiveItem, IHaveRolls
    {
        public ChargedGrapheneRod()
        {
            Name = "TODO";
            IsConsumable = true;
            RollsResult = DiceCalculator.Calculate(7, DiceMessage, 7);
        }

        public bool UnavailableForRestOfCombat { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[1] { Name };

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.GrapheneRodRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //Quantity--;
            //if (Quantity <= 0)
            //{
            //    fight.Player.Items.Remove(this);
            //    fight.Player.ExtraItems.Remove(this);
            //}
            var damage = new DealDamage(RollsResult, fight.Enemies);
            fight.Effects.Enqueue(damage);
            RollsResult = DiceCalculator.Calculate(7, DiceMessage, 7);
            return new List<ICombatResolution>() { damage };
        }
    }
}
