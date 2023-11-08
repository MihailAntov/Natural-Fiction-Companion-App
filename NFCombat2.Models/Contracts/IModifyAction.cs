

namespace NFCombat2.Models.Contracts
{
    public interface IModifyAction
    {
        Task Modify(ICombatAction action);
    }
}
