using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.CombatResolutions
{
    public class Crit : DealDamage
    {

        public Crit(DiceRollResult roll, ICollection<Enemy> targets) : base(roll, targets) { }

        public int CritMultiplier { get; set; } = 2;
        public override MessageType MessageType => MessageType.CritMessage;

        public override string[] MessageArgs
        {
            get
            {
                string[] args = new string[2];
                args[0] = Targets.Count == 1 ? Targets.FirstOrDefault().Name : Targets.Count.ToString();
                args[1] = (Amount * CritMultiplier).ToString();
                return args;
            }
        }

        public override Task Resolve(Fight fight)
        {
            foreach (var target in Targets)
            {
                target.Health -= Amount * CritMultiplier;
            }
            return Task.CompletedTask;
        }
    }
}
