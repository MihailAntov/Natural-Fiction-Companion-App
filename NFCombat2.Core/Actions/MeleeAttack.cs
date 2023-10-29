

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class MeleeAttack : IStandardAction, ITarget
    {
        private readonly Fight _fight;
        public MeleeAttack(Fight fight)
        {
            _fight = fight;
        }

        public string Label => "Melee Attack";
        public string Description { get; set; }

        public ICollection<Enemy> Targets { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 0;

        public void AffectFight(Fight fight)
        {
            
        }
    }
}
