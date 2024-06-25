

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Fights
{
    public class VirtualFight : Fight
    {
        public VirtualFight() : base()
        {
            Type = Common.Enums.FightType.Virtual;
        }

        public override void CheckWinCondition()
        {
            base.CheckWinCondition();

            if (Result != FightResult.None)
            {
                return;
            }

            if (Player.Overload >= Player.MaxOverload)
            {
                Result = FightResult.Lost;
            }
        }


    }
}
