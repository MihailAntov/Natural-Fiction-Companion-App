

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

        public void AffectFight()
        {
            foreach(var enemy in fight.Enemies)
            {
                enemy.Distance -= StaticPlayer.Speed;
                if(enemy.Distance < 0 ) 
                {
                    enemy.Distance = 0;
                }
            }
        }
    }
}
