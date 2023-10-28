using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class BonusAction : IAffectCombat
    {
        public void AffectFight(Fight fight)
        {
            fight.HasBonusAction = true;
        }
    }
}
