using NFCombat2.Models.Player;
namespace NFCombat2.Models.Fights
{
    public class TimedFight : Fight
    {
        public TimedFight(IList<Enemy> enemies, Player.Player player) : base(enemies, player)
        {
        }

       
    }
}
