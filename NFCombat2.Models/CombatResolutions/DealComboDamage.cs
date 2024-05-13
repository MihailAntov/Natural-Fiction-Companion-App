using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.CombatResolutions
{
    public class DealComboDamage : ICombatResolution
    {
        public Enemy Target { get; set; }
        public DealComboDamage(Enemy target, int amount)
        {
            Target = target;
            Amount = amount;
        }

        public int Amount { get; set; }
        public MessageType MessageType => MessageType.DamageMessage;

        public string[] MessageArgs => new string[] { Target.Name, Amount.ToString() };

        public Task Resolve(Fight fight)
        {
            Target.Health -= Amount;
            return Task.CompletedTask;
        }
    }
}
