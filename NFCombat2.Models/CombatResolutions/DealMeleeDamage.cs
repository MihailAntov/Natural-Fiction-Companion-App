﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class DealMeleeDamage : ICombatResolution
    {
        public Enemy Target { get; set; }
        public DealMeleeDamage(Enemy target, int amount)
        {
            Target = target;
            Amount = amount;
        }

        public int Amount { get; set; }
        public MessageType MessageType => MessageType.DamageMessage;

        public string[] MessageArgs => new string[] {Target.Name, Amount.ToString()};

        public Task Resolve(Fight fight)
        {
            Target.Health -= Amount;
            return Task.CompletedTask;
        }
    }
}
