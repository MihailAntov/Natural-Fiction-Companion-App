using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class SkillCheckFight : Fight
    {
        public SkillCheckFight(IList<Enemy> enemies) : base(enemies)
        {
        }

        public override IList<ICombatAction> EnemyActions()
        {
            throw new NotImplementedException();
        }
    }
}
