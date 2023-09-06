

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction
    {
        private readonly Fight fight;
        public PlayerRangedAttack(Fight fight, Enemy enemy)
        {
            this.fight = fight;
        }
        public void AffectFight()
        {
            
        }
    }
}
