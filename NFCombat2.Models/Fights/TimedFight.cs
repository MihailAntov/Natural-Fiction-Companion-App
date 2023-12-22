using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class TimedFight : Fight
    {
        public TimedFight() : base()
        {
        }
        public int MaxTurns { get; set; } = 0;
        public int MinPlayerHealth { get; set; } = 0;
        public int MinEnemyHealth { get; set; } = 0;
        public FightResult OnTurnsReached { get; set; } = FightResult.None;
        public FightResult OnPlayerHealthReached { get; set; } = FightResult.None;
        public FightResult OnEnemyHealthReached { get; set; } = FightResult.None;

        public override void CheckWinCondition()
        {
            if(OnTurnsReached != FightResult.None)
            {
                if(Turn > MaxTurns)
                {
                    Result = OnTurnsReached;
                    return;
                }
            }

            if(OnPlayerHealthReached != FightResult.None)
            {
                if(Player.Health < MinEnemyHealth)
                {
                    Result = OnPlayerHealthReached;
                    return;
                }
            }

            if(OnEnemyHealthReached != FightResult.None)
            {
                if(!Enemies.Any(e=> e.Health > MinEnemyHealth))
                {
                    Result = OnEnemyHealthReached;
                    return;
                }
            }
        }
    }
}
