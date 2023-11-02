

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

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

        public override IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            int amount = DiceRoller.DiceCalculator.Calculate(2);
            var heal = new Heal(amount);
            fight.Effects.Enqueue(heal);
            return new List<ICombatResolution>() { heal };
        }
    }
}
