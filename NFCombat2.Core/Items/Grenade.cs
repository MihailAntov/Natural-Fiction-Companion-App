using NFCombat2.Common.Helpers;

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;

namespace NFCombat2.Models.Items
{
    public class Grenade : Consumable
    {
        public Grenade()
        {
            Label = "Grenade";
        }

        public override string Label { get; set; }
        public override string Description { get; set; } = "Deals two dice worth of damage to each opponent within 10 meters.";

        public override string[] MessageArgs => new string[] { Label };

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var amount = DiceCalculator.Calculate(2);
            var targets = fight.Enemies.Where(e => e.Distance <= 10).ToList();
            ICombatResolution damage = new DealDamage(amount, targets);
            fight.Effects.Enqueue(damage);
            return new List<ICombatResolution>() { damage };
        }
    }
}
