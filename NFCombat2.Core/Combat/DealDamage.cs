using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    internal class DealDamage : IAffectCombat, ITarget
    {
        
        private int _amount;
        public DealDamage(int amount, ICollection<Enemy> targets)
        {
            _amount = amount;
            Targets = targets;
        }

        public ICollection<Enemy> Targets { get; set; }

        public void AffectFight(Fight fight)
        {

            foreach(var target in Targets)
            {
                target.Health -= _amount;
            }
        }
    }
}
