

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class DealMeleeDamage : ICombatResolution
    {
        private Enemy _target;
        public DealMeleeDamage(Enemy target, int amount)
        {
            _target = target;
            Amount = amount;
        }

        public int Amount { get; set; }
        public MessageType MessageType => MessageType.DamageMessage;

        public string[] MessageArgs => new string[] {_target.Name, Amount.ToString()};

        public Task Resolve(Fight fight)
        {
            _target.Health -= Amount;
            return Task.CompletedTask;
        }
    }
}
