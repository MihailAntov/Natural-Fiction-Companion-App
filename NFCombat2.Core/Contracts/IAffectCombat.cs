using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IAffectCombat
    {
        public void AffectFight(Fight fight);
        public string Log(string message);
    }
}
