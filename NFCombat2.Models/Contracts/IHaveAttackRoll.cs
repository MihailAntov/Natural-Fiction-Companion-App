using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveAttackRoll
    {
        Dice.Dice AttackRollResult { get; set; }
        IList<ICombatResolution> AddMissToCombatResolutions(Fight fight);
        IList<ICombatResolution> AddCritToCombatResolutions(Fight fight);
        
        public Accuracy Accuracy { get; }
        public string AttackDiceMessage { get; set; }
        public string[] DiceMessageArgs { get; set; }
        public DiceMessageType AttackDiceMessageType { get; }
        public bool AlwaysHits { get; }
    }
}
