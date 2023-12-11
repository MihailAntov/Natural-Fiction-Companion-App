

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Contracts
{
    public interface IMode
    {
        public string Name { get; set; }
        public ItemMode ItemMode { get; set; }
    }
}
