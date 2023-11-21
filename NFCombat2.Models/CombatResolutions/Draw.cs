using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class Draw : ICombatResolution
    {
        public MessageType MessageType => MessageType.Draw;

        public string[] MessageArgs =>  Array.Empty<string>();

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
