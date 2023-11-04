using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerActionPass : ICombatAction
    {

        private readonly Fight fight;
        public PlayerActionPass(Fight fight)
        {
            this.fight = fight;
        }
        public string[] MessageArgs => Array.Empty<string>();
        public string Label => "Do nothing";
        public string Description => $"Do nothing this turn.";

        public MessageType MessageType => MessageType.ActionPassMessage;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();

            return resolutions;
        }
    }
}
