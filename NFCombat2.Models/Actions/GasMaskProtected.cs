

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class GasMaskProtected : ICombatAction
    {
        public MessageType MessageType => MessageType.GasMaskProteced;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            return new List<ICombatResolution>();
        }
    }
}
