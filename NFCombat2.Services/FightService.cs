using NFCombat2.Models;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;


namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        public Fight GetFightByEpisodeNumber(int episodeNumber)
        {
            var enemies = new List<Enemy>();
            var player = new Soldier();

            switch (episodeNumber)
            {
                case 0:
                    return new RegularFight(enemies, player);
                case 1:
                    return new ChaseFight(enemies, player);
                case 2:
                    return new SoloFight(enemies, player);
                case 3:
                    return new TimedFight(enemies, player);
                default:
                    return new VirtualFight(enemies, player);
            }
        }
    }
}
