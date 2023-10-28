using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IAction : IAffectCombat
    {
        
        public string Label { get; }
    }
}
