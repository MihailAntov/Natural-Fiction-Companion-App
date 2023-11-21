

using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveOpposedRolls
    {
        DiceRollResult AttackerResult { get; set; }
        public string AttackerMessage { get; }
        DiceRollResult DefenderResult { get; set; }
        public string DefenderMessage { get; }
    }
}
