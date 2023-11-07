

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Items
{
    public class MobileHealthKit : Consumable
    {
        public MobileHealthKit()
        {
            Label = "Health Kit";
        }

        public override string Label { get; set; }

        public override string[] MessageArgs => new string[] { Label };
        public override string Description { get; set; } = "Heals you for two dice worth of health.";

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            DiceRollResult roll = DiceCalculator.Calculate(2);
            var heal = new Heal(roll);
            fight.Effects.Enqueue(heal);
            return new List<ICombatResolution>() { heal };
        }
    }
}
