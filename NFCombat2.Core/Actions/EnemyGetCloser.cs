

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class EnemyGetCloser : IMoveAction
    {
        private readonly Fight fight;
        public EnemyGetCloser(Fight fight)
        {
            this.fight = fight;
        }

        public string Label => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public void AffectFight(Fight fight)
        {
            foreach(var enemy in fight.Enemies)
            {
                enemy.Distance -= enemy.Speed;
                if (enemy.Distance < 0)
                {
                    enemy.Distance = 0;
                }
            }
        }
    }
}
