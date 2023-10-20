

using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class VirtualFight : Fight
    {
        public VirtualFight(IList<Enemy> enemies, Player.Player player) : base(enemies, player)
        {

        }

       
    }
}
