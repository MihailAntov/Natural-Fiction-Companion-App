using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class Freeze : IAffectCombat
    {
        private int _turns;
        private IList<Enemy> _targets;
        public Freeze(int turns, IList<Enemy> targets)
        {
            _turns = turns;
            _targets = targets;
        }
        public void AffectFight(Fight fight)
        {
            foreach(var  enemy in _targets)
            {
                enemy.RemainingFrozenTurns += _turns;
            }
        }
    }
}
