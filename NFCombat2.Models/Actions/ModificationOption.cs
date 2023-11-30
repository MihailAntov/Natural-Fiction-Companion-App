using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;


namespace NFCombat2.Models.Actions
{
    public class ModificationOption : IModificationOption
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public AttachedTo ToBeAttachedTo { get; set; }
    }
}
