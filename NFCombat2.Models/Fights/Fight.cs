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
            Type = FightType.Regular;

        }
        
        public FightResult Result { get; set; }
        public bool AllowsPrograms { get; set; } = true;
        public Player.Player Player { get; set; }
        public FightType Type { get; set; } 

        public IList<Enemy> Enemies { get; set; }
        
        public Queue<IAction> Actions { get; set; } = new Queue<IAction>();
        public Queue<ICombatResolution> DelayedEffects { get; set; } = new Queue<ICombatResolution>();

        public Queue<ICombatResolution> Effects { get; set; } = new Queue<ICombatResolution>();
        public bool HasBonusAction { get; set; } = false;
        public int RemainingCrits { get; set; } = 0;

        public int Turn { get; set; } = 1;
        public TurnPhase TurnPhase { get; set; } = TurnPhase.Move;

        public List<Action> TemporaryEffects { get; set; } = new List<Action>();

        public virtual IList<ICombatAction> EnemyMovement()
        {
            var movement = new List<ICombatAction>();
            foreach(var enemy in Enemies)
            {
                enemy.HasMoved = false;
                if (enemy.Range < enemy.Distance && enemy.Speed > 0)
                {
                    movement.Add(new EnemyGetCloser(this, enemy));
                    enemy.HasMoved = true;
                }
            }
            return movement;
        }

        public virtual IList<ICombatAction> EnemyActions()
        {
            
            var actions = new List<ICombatAction>();
            foreach (var enemy in Enemies)
            {
                //TODO : check if enemies can shoot/attack after moving   

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

        public virtual void SetUp()
        {
            foreach(var activatable in Player.Activatables)
            {
                activatable.UnavailableForRestOfCombat = false;
            }
        }

        public virtual void CheckWinCondition()
        {
            if(!Enemies.Any(e=> e.Health > 0))
            {
                Result = FightResult.Won;
                return;
            }
        }

    }
}
