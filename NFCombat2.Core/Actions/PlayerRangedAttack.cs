

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction
    {
        private readonly Fight fight;
        public PlayerRangedAttack(Fight fight)
        {
            this.fight = fight;
        }
        public Enemy Target { get; set; }

        public string Label { get; set; }

        public void AffectFight(Fight fight)
        {
            if(fight.Enemies.Any())
            {
                fight.Enemies.FirstOrDefault().Range++;
            }
        }
    }
}
