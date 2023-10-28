using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    internal class DealDamage : IAffectCombat
    {
        private ICollection<Enemy> _targets;
        private int _amount;
        public DealDamage(int amount, ICollection<Enemy> targets)
        {
            _amount = amount;
            _targets = targets;
        }
        public void AffectFight(Fight fight)
        {

            foreach(var target in _targets)
            {
                target.Health -= _amount;
            }
        }
    }
}
