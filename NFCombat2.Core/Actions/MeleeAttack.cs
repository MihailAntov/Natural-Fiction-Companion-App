

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class MeleeAttack : IStandardAction
    {
        private readonly Fight _fight;
        public MeleeAttack(Fight fight)
        {
            _fight = fight;
        }

        public string Label => "Melee Attack";

        public void AffectFight()
        {
            
        }
    }
}
