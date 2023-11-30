

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Contracts
{
    public interface IModificationOption
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public AttachedTo ToBeAttachedTo { get; set; }
    }
}
