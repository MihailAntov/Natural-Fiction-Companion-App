using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class DealDamage : ICombatResolution
    {

        private DiceRollResult _roll;
        public DealDamage(DiceRollResult roll, ICollection<Enemy> targets)
        {
            _roll = roll;
            Targets = targets;
        }

        public ICollection<Enemy> Targets { get; set; }
        public int Amount => _roll.FlatAmount + _roll.Dice.Select(d=> d.DiceValue).Sum();
        public virtual MessageType MessageType => Targets.Count == 1 ? MessageType.DamageMessage : MessageType.DamageAoeMessage;
        public virtual string[] MessageArgs
        {
            get
            {
                string[] args = new string[2];
                args[0] = Targets.Count == 1 ? Targets.FirstOrDefault().Name : Targets.Count.ToString();
                args[1] = Amount.ToString();
                return args;
            }
        }
        public virtual async Task Resolve(Fight fight)
        {

            foreach (var target in Targets)
            {
                target.Health -= Amount;
            }

        }
    }
}
