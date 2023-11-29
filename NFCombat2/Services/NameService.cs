using NFCombat2.Common.AppConstants;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using static NFCombat2.Common.AppConstants.ItemNames;

namespace NFCombat2.Services
{
    public class NameService : INameService
    {
        public NameService()
        {
            
        }
        public string ItemName(ItemType type)
        {
            try
            {
                return EnglishNames[type];
            }
            catch
            {
                return "not found";
            }
        }

        public string Label(LabelType type)
        {
            throw new NotImplementedException();
        }

        public string ProgramName(ProgramType type)
        {
            throw new NotImplementedException();
        }
    }
}
