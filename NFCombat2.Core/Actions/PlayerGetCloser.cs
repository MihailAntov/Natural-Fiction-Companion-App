

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class PlayerGetCloser : IMoveAction
    {
        private readonly Fight fight;
        public PlayerGetCloser(Fight fight)
        {
            this.fight = fight;
        }

        public void AffectFight()
        {
            foreach(var enemy in fight.Enemies)
            {
                enemy.Distance -= fight.Player.Speed;
                if(enemy.Distance < 0 ) 
                {
                    enemy.Distance = 0;
                }
            }
        }
    }
}
