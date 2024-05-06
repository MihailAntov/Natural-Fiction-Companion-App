

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IModifyAction
    {
        Task Modify(ICombatAction action, Fight fight);
    }
}
