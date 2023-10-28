using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Combat;

namespace NFCombat2.Models.Programs
{
    public class BonusActionEffect : IProgramEffect
    {
        public void AffectFight(Fight fight)
        {
            fight.Effects.Enqueue(new BonusAction());
        }

        
    }
}
