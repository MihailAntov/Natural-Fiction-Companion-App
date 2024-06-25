using NFCombat2.Models.Contracts;
using NFCombat2.Models.Actions;
using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;

namespace NFCombat2.Models.Fights
{
    public class TentacleFight : TimedFight
    {
        public string TraumaTentacleName { get; set; }
        public string IonizationTentacleName { get; set; }
        public string PathogensTentacleName { get; set; }
        public TentacleFight() : base()
        {
            MaxTurns = 10;
            OnTurnsReached = FightResult.Won;
        }

        private ICombatAction TentacleLogic(EnemyType type, string name)
        {
            if (!Enemies.Any(e => e.EnemyType == type))
            {
                return new SpawnTentacle(type, name);
            }
            else
            {
                
                 return new TentacleAttack(type, name);
                
            }
        }
        public override IList<ICombatAction> EnemyActions()
        {
            var result = base.EnemyActions();

            result.Add(TentacleLogic(EnemyType.TraumaTentacle, TraumaTentacleName));
            result.Add(TentacleLogic(EnemyType.PathogenTentacle, PathogensTentacleName));
            result.Add(TentacleLogic(EnemyType.IonizationTentacle, IonizationTentacleName));
            return result;
        }

        public override IList<ICombatAction> EnemyMovement()
        {
            return base.EnemyMovement();
        }

        public override void CheckWinCondition()
        {
            base.CheckWinCondition();

            if (Result != FightResult.None)
            {
                return;
            }

            if (Player.Pathogens >= Player.MaxPathogens || 
                Player.Ionization >= Player.MaxIonization ||
                Player.Trauma >= Player.MaxTrauma)
            {
                Result = FightResult.Lost;
            }
        }

        public bool ProtectedFromMaser { get; set; }
        
        
    }
}
