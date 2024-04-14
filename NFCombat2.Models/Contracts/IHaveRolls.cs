

using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveRolls
    {
        DiceRollResult RollsResult { get; set; }
        public DiceMessageType DiceMessageType { get;  }
        public string DiceMessage { get; set; }
        public string[] DiceMessageArgs { get; set; }
    }
}
