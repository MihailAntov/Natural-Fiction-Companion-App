

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction, ITarget
    {
        private readonly Fight fight;
        public PlayerRangedAttack(Fight fight, Weapon weapon)
        {
            this.fight = fight;
            MinRange = weapon.MinRange;
            MaxRange = weapon.MaxRange;
            AreaOfEffect = weapon.AreaOfEffect;
        }
        public Enemy Target { get; set; }

        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<Enemy> Targets { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public void AffectFight(Fight fight)
        {
            if(fight.Enemies.Any())
            {
                fight.Enemies.FirstOrDefault().Range++;
            }
        }
    }
}
