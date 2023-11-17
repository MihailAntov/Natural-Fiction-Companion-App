using NFCombat2.Common.Helpers;

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class HandGrenade : CombatActiveItem, IHaveRolls
    {
        public HandGrenade()
        {
            Label = "Grenade";
            Name = "Grenade";
            RollsResult = DiceCalculator.Calculate(2);
            Description = "Deals two dice worth of damage to each opponent within 10 meters.";
            IsConsumable = true;
        }

        public override string[] MessageArgs => new string[] { Label };

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage => "Your grenade's damage:";

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
