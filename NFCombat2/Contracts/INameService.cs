

using NFCombat2.Common.Enums;

namespace NFCombat2.Contracts
{
    public interface INameService
    {
        public string ItemName(ItemType type);
        public string ItemDescription(ItemType type);
        public string ProgramName(ProgramType type);
        public string Label(LabelType type);
        public string ModeName(ItemMode mode);
    }
}
