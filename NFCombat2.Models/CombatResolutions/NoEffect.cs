
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class NoEffect : ICombatResolution
    {
        private string _effectName;
        public NoEffect(string effectName)
        {
            _effectName = effectName;
        }
        public MessageType MessageType => MessageType.NoEffect;

        public string[] MessageArgs => new string[1] { _effectName };

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
