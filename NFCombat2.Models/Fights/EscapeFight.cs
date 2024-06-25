using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;


namespace NFCombat2.Models.Fights
{
    public class EscapeFight : Fight
    {
        public EscapeFight() : base()
        {
            Type = FightType.Escape;
        }

        public int TurnsSkipped { get; set; } = 0;

        public override void CheckWinCondition()
        {
            base.CheckWinCondition();

            if (Result != FightResult.None)
            {
                return;
            }

            if (TurnsSkipped >= 5)
            {
                Result = FightResult.Escaped;
                return;
            }
        }
    }
}
