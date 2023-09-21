

using NFCombat2.Models.Player;

namespace NFCombat2.Models.Fights
{
    public class RegularFight : Fight
    {
        public RegularFight(IList<Enemy> enemies, PlayerBase player) : base(enemies, player)
        {
        }

        
    }
}
