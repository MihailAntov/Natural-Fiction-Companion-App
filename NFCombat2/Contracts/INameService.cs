
using NFCombat2.Models.Fights;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Parts;

namespace NFCombat2.Contracts
{
    public interface INameService
    {
        public string ItemName(ItemType type);
        public string ItemDescription(ItemType type);
        public string ProgramName(ProgramType type);
        public string PartCategoryName(PartCategoryType categoryType);
        public string PartName(PartType part);
        public string Option(OptionType option, CheckType checkType = CheckType.None);
        public string Label(LabelType type);
        public string ModeName(ItemMode mode);
        public string FightResultMessage(Fight fight);
        public string InfoMessage(Fight fight);
        public string EnemyName(EnemyType enemyType);
        public void RetrieveFightNames(Fight fight);
    }
}
