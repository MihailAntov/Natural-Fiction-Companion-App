

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models;
using NFCombat2.Models.Actions;

namespace NFCombat2.Services.Contracts
{
    public interface IOptionsService
    {
        ICollection<IAction> GetPrograms(Fight fight);
        ICollection<IAction> GetItems(Fight fight);
        ICollection<IAction> GetOptions(Fight fight, string category);
        ICollection<IAction> GetTargets(Fight fight, int? hand);
        ICollection<string> GetCategories (Fight fight);    
        ICollection<string> GetBonusCategories(Fight fight);    
    }
}
