
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IModifyAccuracy
    {
        Task Modify(ICombatAction action, Fight fight);
    }
}
