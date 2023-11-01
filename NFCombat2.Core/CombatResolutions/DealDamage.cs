using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class DealDamage : ICombatResolution
    {

        private int _amount;
        public DealDamage(int amount, ICollection<Enemy> targets)
        {
            _amount = amount;
            Targets = targets;
        }

        public ICollection<Enemy> Targets { get; set; }

        public MessageType MessageType => Targets.Count == 1 ? MessageType.DamageMessage : MessageType.DamageAoeMessage;
        public string[] MessageArgs
        {
            get
            {
                string[] args = new string[2];
                args[0] = Targets.Count == 1 ? Targets.FirstOrDefault().Name : Targets.Count.ToString();
                args[1] = _amount.ToString();
                return args;
            }
        }
        public void Resolve(Fight fight)
        {

            foreach (var target in Targets)
            {
                target.Health -= _amount;
            }

        }
    }
}
