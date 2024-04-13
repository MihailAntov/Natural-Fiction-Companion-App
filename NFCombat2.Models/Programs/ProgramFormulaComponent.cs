

using NFCombat2.Common.Enums;
using static NFCombat2.Common.AppConstants.ProgramComponentNames;

namespace NFCombat2.Models.Programs
{
    public class ProgramFormulaComponent
    {
        public string Formula
        {
            get
            {
                string result = Positive ? string.Empty : "N";
                result += Type.ToString();
                return result;
            }
        }
        public string Name { get; set; }
        public bool Positive { get; set; }
        public ProgramComponentType Type { get; set; }
    }
}
