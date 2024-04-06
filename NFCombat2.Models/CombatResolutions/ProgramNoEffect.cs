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
        public MessageType MessageType => MessageType.ProgramNoEffect;

        public string[] MessageArgs => Array.Empty<string>();

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
