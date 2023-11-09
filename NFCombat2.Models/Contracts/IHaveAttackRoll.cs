using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveAttackRoll
    {
        Dice AttackRollResult { get; set; }
        IList<ICombatResolution> AddMissToCombatResolutions(Fight fight);
        IList<ICombatResolution> AddCritToCombatResolutions(Fight fight);
        public Accuracy Accuracy { get; set; }
        public string AttackDiceMessage { get; }
    }
}
