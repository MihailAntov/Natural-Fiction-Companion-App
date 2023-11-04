using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface ICombatAction
    {
        public IList<ICombatResolution> AddToCombatEffects(Fight fight);
        public MessageType MessageType { get; }
        public string[] MessageArgs { get; }
    }
}
