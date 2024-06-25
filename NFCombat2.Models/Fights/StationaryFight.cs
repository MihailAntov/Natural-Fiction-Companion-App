

using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Fights
{
    public class StationaryFight : TimedFight
    {
        public StationaryFight() : base()
        {
            Type = Common.Enums.FightType.Stationary;
        }

        public override IList<ICombatAction> EnemyMovement()
        {
            var actions = new List<ICombatAction>();
            foreach(var enemy in Enemies)
            {
                actions.Add(new EnemyGetFurther(this, enemy));
            }
            return actions;
        }

        public override IList<ICombatAction> EnemyActions()
        {
            return new List<ICombatAction>();
        }

        public override void CheckWinCondition()
        {
            base.CheckWinCondition();

            if (Result != FightResult.None)
            {
                return;
            }

            if (!Enemies.Any(e=> e.Health > MinEnemyHealth))
            {
                Result = OnEnemyHealthReached;
                return;
            }

            //Marker : Programs
            if(Player.Weapons.Any(w=> w.EffectiveMaxRange >= Enemies.FirstOrDefault().Distance) ||
                Player.Programs.Any(w => w.MaxRange >= Enemies.FirstOrDefault().Distance) ||
                Player.Items.OfType<ITarget>().Any(w => w.MaxRange >= Enemies.FirstOrDefault().Distance))
            {
                return;
            }

            Result =  FightResult.Lost;
            
        }
    }
}
