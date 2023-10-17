using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IAction
    {
        public void AffectFight();
        public string Label { get; }
    }
}
