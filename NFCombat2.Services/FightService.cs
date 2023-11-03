using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Services.Contracts;
using NFCombat2.Models.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Items;
using NFCombat2.Common.Enums;
using System.ComponentModel;

namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        private Fight _fight;
        private readonly ILogService _logService;
        private readonly IOptionsService _optionsService;
        public FightService(ILogService logService, IOptionsService optionsService)
        {
            _logService = logService;
            _optionsService = optionsService;
        }

        public ITarget CurrentTargetingEffect {get; set;}

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
                Distance = 10,
                Speed = 2
            };

            var targetDummy2 = new Enemy()
            {
                Name = "Target Dummy Test Long Text",
                Health = 10,
                Distance = 15,
                Speed = 2
            };
            enemies.Add(targetDummy);

            var hacker = new Hacker() {Name = "Istvan" };
            hacker.Weapons.Add(new Weapon() { MinRange = 0, MaxRange = 8, DamageDice = 1 });
            hacker.Consumables.Add(new MobileHealthKit());
            hacker.Consumables.Add(new Grenade());
            Fight fight;
            
            switch (episodeNumber)
            {
                case 0:
                    fight = new RegularFight(enemies, hacker);
                    enemies.Add(targetDummy2);
                    break;
                case 1:
                    fight = new ChaseFight(enemies, hacker);
                    break;
                case 2:
                    fight = new SoloFight(enemies, hacker);
                    break;
                case 3:
                    fight = new TimedFight(enemies, hacker);
                    break;
                default:
                    fight = new VirtualFight(enemies, hacker);
                    break;
            }
            _fight = fight;
            return fight;
        }

        public IOptionList AfterOption()
        {
            ResolveEffects();
            switch(++_fight.TurnPhase)
            {
                case TurnPhase.Move:
                    return _optionsService.GetMoveActions(_fight);
                case TurnPhase.Action:
                    return _optionsService.GetStandardActions(_fight);
                case TurnPhase.Bonus:
                    if (!_fight.HasBonusAction)
                    {
                        return AfterOption();
                    }
                    return _optionsService.GetBonusActions(_fight);
                case TurnPhase.EnemyMove:
                    //TODO call enemy combat logic
                    _fight.TurnPhase = TurnPhase.None;
                    return AfterOption();
                
                default:
                    throw new InvalidEnumArgumentException(nameof(TurnPhase));
            }
        }

        public void ResolveEffects()
        {
            while(_fight.Effects.Count > 0)
            {
                var effect = _fight.Effects.Dequeue();
                effect.Resolve(_fight);
                
            }
        }

        public void AddEffect(ICombatAction effect)
        {
            _logService.Log(effect.MessageType, effect.MessageArgs);
            var resolutions = effect.AddToCombatEffects(_fight);
            foreach(var resolution in resolutions)
            {
                _logService.Log(resolution.MessageType, resolution.MessageArgs);
            }
        }

        public IOptionList ProcessChoice(object option)
        {
            IOptionList result = new OptionList();
            
            if (option is string category)
            {
                switch (category)
                {
                    case "Programs":

                        result = _optionsService.GetPrograms(_fight);
                        break;
                    case "Shoot":
                    case "Attack":
                    case "Wait":
                        return AfterOption();
                    case "Items":
                        result = _optionsService.GetItems(_fight);
                        break;
                    case "Move":
                        var effect = new PlayerGetCloser(_fight);
                        AddEffect(effect);
                        return AfterOption();
                }
                return result;

            }

            if (option is ITarget targetingEffect && !targetingEffect.AreaOfEffect)
            {

                CurrentTargetingEffect = targetingEffect;
                var targets = _optionsService.GetTargets(_fight, targetingEffect.MinRange, targetingEffect.MaxRange);
                
                return targets;


            }

            if (option is Enemy target)
            {
                CurrentTargetingEffect.Targets.Add(target);
                var effect = (ICombatAction)CurrentTargetingEffect;
                AddEffect(effect);
                return AfterOption();

            }


            if (option is ICombatAction combatEffect)
            {
                AddEffect(combatEffect);
                return AfterOption();

            }

            return _optionsService.GetMoveActions(_fight);  
        }
    }
}
