
using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class SoloFight : Fight
    {
        public SoloFight(IList<Enemy> enemies, PlayerBase player) : base(enemies, player)
        {
        }

        
    }
}
