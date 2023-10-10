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
            
            Fight fight;
            switch (episodeNumber)
            {
                case 0:
                    fight = new RegularFight(enemies);
                    break;
                case 1:
                    fight = new ChaseFight(enemies);
                    break;
                case 2:
                    fight = new SoloFight(enemies);
                    break;
                case 3:
                    fight = new TimedFight(enemies);
                    break;
                default:
                    fight = new VirtualFight(enemies);
                    break;
            }
            return fight;
        }
    }
}
