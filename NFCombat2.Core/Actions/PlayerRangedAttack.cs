

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

        public string Label => "Shoot";

        public void AffectFight(Fight fight)
        {
            if(fight.Enemies.Any())
            {
                fight.Enemies.FirstOrDefault().Range++;
            }
        }
    }
}
