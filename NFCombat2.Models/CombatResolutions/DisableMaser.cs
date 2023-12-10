

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class DisableMaser : ICombatResolution
    {
        private Fight _fight;
        
        public MessageType MessageType => MessageType.ProtectedFromMaser;

        public string[] MessageArgs => Array.Empty<string>();

        public Task Resolve(Fight fight)
        {
            if(fight is TentacleFight tentacleFight)
            {
                tentacleFight.ProtectedFromMaser = true;
            }
            return Task.CompletedTask;
        }
    }
}
