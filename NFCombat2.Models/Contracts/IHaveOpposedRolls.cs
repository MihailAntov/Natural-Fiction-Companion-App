

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveOpposedRolls
    {
        DiceRollResult AttackerResult { get; set; }
        public string AttackerMessage { get; set; }
        public DiceMessageType AttackerDiceMessageType { get;  }
        DiceRollResult DefenderResult { get; set; }
        public string DefenderMessage { get; set; }
        public DiceMessageType DefenderDiceMessageType { get;  }
        public string[] DiceMessageArgs { get; set; }
    }
}
