

namespace NFCombat2.Models.Contracts
{
    public interface IDelayedAction : IAction
    {
        public int TurnsLeft { get; set; }
    }
}
