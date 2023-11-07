using NFCombat2.Common.Helpers;

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using CommunityToolkit.Maui.Views;

namespace NFCombat2.Models.Items
{
    public class Grenade : Consumable, IHaveRolls
    {
        public Grenade()
        {
            Label = "Grenade";
            RollsResult = DiceCalculator.Calculate(2);
        }

        public override string Label { get; set; }
        public override string Description { get; set; } = "Deals two dice worth of damage to each opponent within 10 meters.";

        public override string[] MessageArgs => new string[] { Label };

        public DiceRollResult RollsResult { get; set; }

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
