using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class SoloFight : Fight
    {
        public SoloFight(IList<Enemy> enemies, Player.Player player) : base(enemies, player)
        {
        }

        public override IList<IAction> EnemyActions()
        {
            throw new NotImplementedException();
        }
    }
}
