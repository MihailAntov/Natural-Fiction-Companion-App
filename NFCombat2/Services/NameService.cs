using NFCombat2.Common.AppConstants;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.AppConstants.ItemNames;
using static NFCombat2.Common.AppConstants.Labels;
using static NFCombat2.Common.AppConstants.ModeNames;
using static NFCombat2.Common.AppConstants.FightResults;

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

        public string ItemDescription(ItemType type)
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
            try
            {
                return EnglishLabels[type];
            }
            catch
            {
                return "not found";
            }
        }

        public string ProgramName(ProgramType type)
        {
            throw new NotImplementedException();
        }

        public string ModeName(ItemMode mode)
        {
            return EnglishModes[mode];
        }

        public string FightResultMessage(Fight fight)
        {
            
            return EnglishFightResults[(fight.Type,fight.Result)];
            
        }
    }
}
