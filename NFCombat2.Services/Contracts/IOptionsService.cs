

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models;
using NFCombat2.Models.Actions;

namespace NFCombat2.Services.Contracts
{
    public interface IOptionsService
    {
        ICollection<Program> GetPrograms(Fight fight);
        ICollection<Item> GetItems(Fight fight);
        ICollection<IAction> GetOptions(Fight fight, string category);
        ICollection<PlayerRangedAttack> GetTargets(Fight fight, int? hand);
        ICollection<string> GetCategories (Fight fight);    
    }
}
