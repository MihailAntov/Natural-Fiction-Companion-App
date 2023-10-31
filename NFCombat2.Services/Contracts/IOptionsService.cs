

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models;
using NFCombat2.Models.Actions;

namespace NFCombat2.Services.Contracts
{
    public interface IOptionsService
    {
        //ICollection<IAction> GetPrograms(Fight fight);
        //ICollection<IAction> GetItems(Fight fight);
        //ICollection<Enemy> GetTargets(Fight fight, int minRange = 0, int maxRange = 1000);
        //ICollection<string> GetCategories (Fight fight);    
        //ICollection<string> GetBonusCategories(Fight fight);

        ICollection<IOption> GetPrograms(Fight fight);
        ICollection<IOption> GetItems(Fight fight);
        ICollection<IOption> GetTargets(Fight fight, int minRange = 0, int maxRange = 1000);
        ICollection<IOption> GetStandardActions(Fight fight);
        ICollection<IOption> GetMoveActions(Fight fight);
        ICollection<IOption> GetBonusActions(Fight fight);
    }
}
