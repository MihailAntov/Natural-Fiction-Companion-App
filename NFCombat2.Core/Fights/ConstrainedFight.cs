using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class ConstrainedFight : Fight
    {
        public ConstrainedFight(IList<Enemy> enemies, Player.Player player) : base(enemies, player)
        {

        }

        public override IList<ICombatAction> EnemyActions()
        {
            throw new NotImplementedException();
        }
    }
}
