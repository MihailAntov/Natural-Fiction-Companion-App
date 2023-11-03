

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction, ITarget
    {
        private readonly Fight fight;
        private readonly Weapon _weapon;
        public PlayerRangedAttack(Fight fight, Weapon weapon)
        {
            this.fight = fight;
            MinRange = weapon.MinRange;
            MaxRange = weapon.MaxRange;
            AreaOfEffect = weapon.AreaOfEffect;
            _weapon = weapon;
        }
        public Enemy Target { get; set; }
        public string[] MessageArgs => new string[] { Target?.Name, Label };
        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<Enemy> Targets { get; set; } = new HashSet<Enemy>();
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType => MessageType.ShootMessage;

        public IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>() { new DealDamage(3, Targets) };
            
            _weapon.Cooldown += _weapon.CooldownPerShot;
            return resolutions;
            

        }
    }
}
