using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface ICombatResolution
    {
        public Task Resolve(Fight fight);
        public MessageType MessageType { get; }
        public string[] MessageArgs { get; }
    }
}
