using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class SkillCheckFight : Fight
    {
        public int WonRounds { get; set; } = 0;
        public bool WonLastRound { get; set; } = false;
        public int ConsecutiveWins { get; set; } = 0;
        public int MaxConsecutiveWins { get; set; } = 0;
        public int MaxRounds { get; set; } = 0;
        public int MinStrength { get; set; } = 0;
        public bool LosingAtZeroFatal { get; set; } = false;
        public bool CountWins { get; set; } = false;

        public FightResult OnMaxRoundsReached { get; set; } = FightResult.None;
        public FightResult OnMinStrengthReached { get; set; } = FightResult.None;
        public FightResult OnMaxConsecutiveRoundsReached { get; set; } = FightResult.None;
        
        public CheckType CheckType { get; set; }
        public SkillCheckFight(IList<Enemy> enemies, CheckType type) : base(enemies)
        {
            CheckType = type;
            Type = FightType.SkillCheck;
            WeaponsContributeStrength = false;
        }

        public override IList<ICombatAction> EnemyActions()
        {
            return new List<ICombatAction>();
        }

        public override void CheckWinCondition()
        {
            if(OnMaxConsecutiveRoundsReached != FightResult.None)
            {
                if(ConsecutiveWins >= MaxConsecutiveWins)
                {
                    Result = OnMaxConsecutiveRoundsReached;
                }
            }

            if (OnMaxRoundsReached != FightResult.None)
            {
                if (Turn >= MaxRounds)
                {
                    Result = OnMaxRoundsReached;
                }
            }

            if(OnMinStrengthReached != FightResult.None)
            {
                if(PlayerStrength <= MinStrength)
                {
                    Result = OnMinStrengthReached;
                }
            }
        }

        public override void SetUp()
        {
            PlayerStrength = Player.StrengthWithoutWeapon;
            base.SetUp();

        }
    }
}
