

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Contracts
{
    public interface IAddable
    {
        string Name { get; set; }
        bool IsInvention { get; set; }
        public ItemType ItemType { get; set; }
        public int Id { get; set; }
    }
}
