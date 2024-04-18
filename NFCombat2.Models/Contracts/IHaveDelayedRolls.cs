

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveDelayedRolls
    {
        DiceRollResult DelayedRollsResult { get; set; }
        public DiceMessageType DelayedDiceMessageType { get; }
    }
}
