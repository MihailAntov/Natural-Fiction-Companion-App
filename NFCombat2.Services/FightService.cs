using NFCombat2.Models;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;


namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        public async Task<Fight> GetFightByEpisodeNumber(int episodeNumber)
        {
            var enemies = new List<Enemy>();
            var player = new Soldier();
            Fight fight;
            switch (episodeNumber)
            {
                case 0:
                    fight = new RegularFight(enemies, player);
                    break;
                case 1:
                    fight = new ChaseFight(enemies, player);
                    break;
                case 2:
                    fight = new SoloFight(enemies, player);
                    break;
                case 3:
                    fight = new TimedFight(enemies, player);
                    break;
                default:
                    fight = new VirtualFight(enemies, player);
                    break;
            }
            return fight;
        }
    }
}
