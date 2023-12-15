using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;

namespace NFCombat2.Models.Fights
{
    public class ChaseFight : Fight
    {
        private bool leaderJoined = false;
        public ChaseFight(IList<Enemy> enemies) : base(enemies)
        {
            Type = Common.Enums.FightType.Chase;
        }

        public override IList<ICombatAction> EnemyMovement()
        {
            var movement = new List<ICombatAction>();
            foreach (var enemy in Enemies)
            {
                if(enemy.Distance > 0)
                {
                    var action = new EnemyGetCloser(this, enemy);
                    movement.Add(action);
                }
            }
            return movement;
        }

        public override IList<ICombatAction> EnemyActions()
        {
            if(!Enemies.Any(e=> e.Range > 0 && e.Health > 0))
            {
                leaderJoined = true;
            }

            var actions = new List<ICombatAction>();


            foreach (var enemy in Enemies)
            {

                if(enemy.Distance == 0 && enemy.Range > 0 && enemy.Health > 0)
                {
                    actions.Add(new EnemyMeleeAttack(this, enemy));
                }else if (enemy.Distance == 0 && enemy.Range == 0 && leaderJoined)
                {
                    actions.Add(new EnemyMeleeAttack(this, enemy));
                }
                else if (enemy.Range >= enemy.Distance && enemy.Range > 0)
                {
                    actions.Add(new EnemyRangedAttack(this, enemy));
                }


            }

            return actions;
        }
    }
}
