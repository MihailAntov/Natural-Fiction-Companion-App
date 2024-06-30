

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class ManualProgramCast : IAction
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MessageType MessageType => MessageType.None;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            return new List<ICombatResolution>();   
        }
    }
}
