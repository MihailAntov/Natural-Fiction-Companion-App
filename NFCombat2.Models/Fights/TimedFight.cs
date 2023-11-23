using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class TimedFight : Fight
    {
        public TimedFight(IList<Enemy> enemies) : base(enemies)
        {
        }

        public override IList<ICombatAction> EnemyActions()
        {
            throw new NotImplementedException();
        }
    }
}
