

namespace NFCombat2.Models.Contracts
{
    public interface IModifyResolution
    {
        //returns any potential further resolutions that need to happen
        Task<List<ICombatAction>> Modify(ICombatResolution resolution);
    }
}
