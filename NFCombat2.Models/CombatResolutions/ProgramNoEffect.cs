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
    internal class ProgramNoEffect : ICombatResolution
    {
        private int _overloadCost;
        public ProgramNoEffect(MessageType messageType,int overloadCost)
        {
            _overloadCost   = overloadCost;
            MessageType = messageType;
        }
        public MessageType MessageType { get; set; }

        public string[] MessageArgs => new string[1] {_overloadCost.ToString()};

        public Task Resolve(Fight fight)
        {
            fight.Player.Overload += _overloadCost;
            return Task.CompletedTask;
        }
    }
}
