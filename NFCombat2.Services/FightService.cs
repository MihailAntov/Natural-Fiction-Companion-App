using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Models.Combat;
using NFCombat2.Services.Contracts;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        private Fight _fight;
        public Fight GetFight()
        {
            return _fight;
        }

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
                    fight = new RegularFight(enemies, fighter);
                    enemies.Add(targetDummy2);
                    break;
                case 1:
                    fight = new ChaseFight(enemies, fighter);
                    break;
                case 2:
                    fight = new SoloFight(enemies, fighter);
                    break;
                case 3:
                    fight = new TimedFight(enemies, fighter);
                    break;
                default:
                    fight = new VirtualFight(enemies, fighter);
                    break;
            }
            _fight = fight;
            return fight;
        }

        public void ResolveEffects()
        {
            foreach(var effect in _fight.Effects)
            {
                effect.AffectFight(_fight);
            }
        }

        public void SelectAction(IAffectCombat effect)
        {
            effect.AffectFight(_fight);
        }
    }
}
