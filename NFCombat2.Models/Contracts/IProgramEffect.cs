using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface IProgramEffect : ICombatAction
    {
        public bool HasEffect(Fight fight);
        public int Cost { get; set; }
    }
}
