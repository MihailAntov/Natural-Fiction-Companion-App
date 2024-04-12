

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Programs
{
    public class ProgramFormulaComponent
    {
        public string Formula { get; set; } 
        public string Name { get; set; }
        public bool Positive { get; set; }
        public ProgramComponentType Type { get; set; }
    }
}
