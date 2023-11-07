

using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveRolls
    {
        DiceRollResult RollsResult { get; set; }
    }
}
