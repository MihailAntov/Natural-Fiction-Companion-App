

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerMeleeAttack : IStandardAction, ITarget
    {
        private readonly Fight _fight;
        public PlayerMeleeAttack(Fight fight)
        {
            _fight = fight;
        }
        public string[] MessageArgs => new string[] { Target?.Name };
        public string Label => "Melee Attack";
        public string Description { get; set; }

        public ICollection<Enemy> Targets { get; set; }
        public Enemy Target { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 0;

        public MessageType MessageType => MessageType.AttackMessage;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            return null;
        }
    }
}
