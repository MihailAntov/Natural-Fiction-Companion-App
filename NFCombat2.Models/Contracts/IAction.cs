using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IAction : ICombatAction
    {
        
        public string Name { get; }
        public string Description { get; }
    }
}
