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

            var targetDummy = new Enemy()
            {
                Name = "Target Dummy",
                Health = 10,
                Range = 5,
                Speed = 2
            };

            var targetDummy2 = new Enemy()
            {
                Name = "Target Dummy",
                Health = 10,
                Range = 5,
                Speed = 2
            };
            enemies.Add(targetDummy);

            var fighter = new Soldier();

            Fight fight;
            
            switch (episodeNumber)
            {
                case 0:
                    fight = new RegularFight(enemies);
                    enemies.Add(targetDummy2);
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
            fight.Player = fighter;
            return fight;
        }
    }
}
