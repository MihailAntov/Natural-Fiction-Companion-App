using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;
using NFCombat2.Models.SpecOps;

namespace NFCombat2.Contracts
{
    public interface IPopupService
    {
        void ShowPopup(Popup popup);
        void ShowToast(string text);
        Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect, Player player, bool canReroll, bool canFreeReroll);
        Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect, Player player, bool canReroll, bool canFreeReroll);
        Task<TaskCompletionSource<bool>> ShowMeleeCombatRollsPopup(IHaveOpposedRolls effect, Player player, bool canReroll, bool canFreeReroll);
        Task<ProgramExecution> ShowCastPopup(IPlayerService playerService);
        Task<Player> ShowAddProfilePopup(IPlayerService playerService);
        Task<Technique> ShowTechniquePopup(List<TechniqueChoice> choices);
        Task<IAddable> ShowEntryWithSuggestionsPopup(ICollection<IAddable> effect, IPlayerService playerService);
        Task<Hand> ShowHandChoicePopup(INameService nameSerivce);
    }
}
