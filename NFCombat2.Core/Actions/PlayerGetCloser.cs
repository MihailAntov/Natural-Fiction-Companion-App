

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;

namespace NFCombat2.Models.Actions
{
    public class PlayerGetCloser : IMoveAction
    {
        private readonly Fight fight;
        public PlayerGetCloser(Fight fight)
        {
            this.fight = fight;
        }

        public string Label => "Get Closer";
        public string Description => $"Lower the distance to the enemy by {fight.Player.Speed}";

        public void AffectFight(Fight fight)
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
