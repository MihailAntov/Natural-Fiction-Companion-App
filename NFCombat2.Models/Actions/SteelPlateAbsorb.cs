using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    internal class SteelPlateAbsorb : ICombatAction
    {
        private int _amountAbsorbed;
        private int _remainingDurability;
        public SteelPlateAbsorb(int amountAbsorbed, int remainingDurability)
        {
            _amountAbsorbed = amountAbsorbed;
            _remainingDurability = remainingDurability;
        }
        public MessageType MessageType => MessageType.SteelPlateAbsorb;

        public string[] MessageArgs => new string[2] {_amountAbsorbed.ToString(),  _remainingDurability.ToString()};

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            return new List<ICombatResolution>();
        }
    }
}
