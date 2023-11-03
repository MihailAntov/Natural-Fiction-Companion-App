using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerMovePass : ICombatAction
    {

        private readonly Fight fight;
        public PlayerMovePass(Fight fight)
        {
            this.fight = fight;
        }
        public string[] MessageArgs => Array.Empty<string>();
        public string Label => "Stay";
        public string Description => $"Stay where you are";

        public MessageType MessageType => MessageType.MovePassMessage;

        public IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            
            return resolutions;
        }
    }
}
