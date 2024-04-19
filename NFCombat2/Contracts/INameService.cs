
using NFCombat2.Models.Fights;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Contracts
{
    public interface INameService
    {
        public string ItemName(ItemType type);
        public string ItemDescription(ItemType type);
        public string ProgramName(ProgramType type);
        public string ProgramComponentName(ProgramComponentType type);
        public string ProgramDescription(ProgramType type);
        public string PartCategoryName(PartCategoryType categoryType);
        public string PartName(PartType part);
        public string Option(OptionType option, CheckType checkType = CheckType.None, int healthCost = 0);
        public string Label(LabelType type);
        public string ModeName(ItemMode mode);
        public string FightResultMessage(Fight fight);
        public string CraftResultMessage(CraftResult result, IAddable item);
        public string InfoMessage(Fight fight);
        public string EnemyName(EnemyType enemyType);
        public void RetrieveFightNames(Fight fight);
        public string ClassName(PlayerClass className);
        public string DiceMessage(DiceMessageType messageType, string[] messageArgs);
        public string TechniqueName(TechniqueType techniqueType);
        public string TechniqueDescription(TechniqueType techniqueType);
    }
}
