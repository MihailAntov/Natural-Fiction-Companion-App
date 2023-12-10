using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;


using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;


namespace NFCombat2.Models.Fights
{
    public class Fight
    {
        public int Id { get; set; }
        public Fight(IList<Enemy> enemies)
        {
            Enemies = enemies;
            Result = FightResult.None;
        }
        
        public FightResult Result { get; set; }

        public Player.Player Player { get; set; }

        public IList<Enemy> Enemies { get; set; }
        
        public Queue<IAction> Actions { get; set; } = new Queue<IAction>();
        public Queue<ICombatResolution> DelayedEffects { get; set; } = new Queue<ICombatResolution>();

        public Queue<ICombatResolution> Effects { get; set; } = new Queue<ICombatResolution>();
        public bool HasBonusAction { get; set; } = false;
        public int RemainingCrits { get; set; } = 0;

        public int Turn { get; set; } = 1;

        public TurnPhase TurnPhase { get; set; } = TurnPhase.Move;

        public virtual IList<ICombatAction> EnemyActions()
        {
            if(!Enemies.Any(e=> e.Health > 0))
            {
                Result = FightResult.Won;
            }

            var actions = new List<ICombatAction>();
            foreach (var enemy in Enemies)
            {
                if (enemy.Range < enemy.Distance)
                {
                    actions.Add(new EnemyGetCloser(this, enemy));
                }


                if (enemy.Distance == 0)
                {
                    actions.Add(new EnemyMeleeAttack(this, enemy));
                }
                else if (enemy.Range >= enemy.Distance)
                {
                    actions.Add(new EnemyRangedAttack(this, enemy));
                }

                
            }

            return actions;
        }



    }
}
