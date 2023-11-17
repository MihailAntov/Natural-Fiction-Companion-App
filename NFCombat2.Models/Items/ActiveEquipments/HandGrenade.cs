using NFCombat2.Common.Helpers;

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class HandGrenade : Item, ICombatActiveItem, IHaveRolls
    {
        public HandGrenade()
        {
            Label = "Grenade";
            Name = "Grenade";
            RollsResult = DiceCalculator.Calculate(2);
            Description = "Deals two dice worth of damage to each opponent within 10 meters.";
            IsConsumable = true;
        }
        public string Label { get; set; }
        public string[] MessageArgs => new string[] { Label };

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage => "Your grenade's damage:";

        public MessageType MessageType => MessageType.UseItemMessage;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var amount = DiceCalculator.Calculate(2);
            var targets = fight.Enemies.Where(e => e.Distance <= 10).ToList();
            ICombatResolution damage = new DealDamage(amount, targets);
            fight.Effects.Enqueue(damage);
            return new List<ICombatResolution>() { damage };
        }


    }
}
