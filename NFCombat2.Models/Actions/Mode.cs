

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Actions
{
    public class Mode : IMode
    {
        public string Name { get; set; }
        public ItemMode ItemMode { get; set; }
    }
}
