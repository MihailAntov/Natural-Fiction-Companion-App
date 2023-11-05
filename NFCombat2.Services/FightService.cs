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
using CommunityToolkit.Maui.Alerts;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        private Fight _fight;
        private readonly ILogService _logService;
        private readonly IOptionsService _optionsService;
        private readonly IPopupService _popupService;
        public FightService(ILogService logService, IOptionsService optionsService, IPopupService popupService)
        {
            _logService = logService;
            _optionsService = optionsService;
            _popupService = popupService;
        }

        public ITarget CurrentTargetingEffect {get; set;}
        public IOptionList PreviousOptions { 
            get 
            {                
                optionHistory.Pop();
                return optionHistory.Peek();
            }
            set
            {
                
                optionHistory.Push(value);
            }
        }

        private Stack<IOptionList> optionHistory = new Stack<IOptionList>();
        private IOptionList optionBuffer;
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
            var specOps = new SpecOps() { Name = "Hackerman" };
            hacker.Weapons.Add(new Weapon() { Label="Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1 });
            hacker.Weapons.Add(new Weapon() { Label="Sniper Rifle", MinRange = 5, MaxRange = 20, DamageDice = 1 });
            hacker.Consumables.Add(new MobileHealthKit());
            hacker.Consumables.Add(new Grenade());
            specOps.Weapons.Add(new Weapon() { Label = "Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1 });
            specOps.Consumables.Add(new MobileHealthKit());
            specOps.Consumables.Add(new Grenade());
            Fight fight;
            
            switch (episodeNumber)
            {
                case 0:
                    fight = new Fight(enemies, hacker);
                    enemies.Add(targetDummy2);
                    break;
                case 1:
                    fight = new ChaseFight(enemies, specOps);
                    break;
                case 2:
                    fight = new SoloFight(enemies, hacker);
                    break;
                case 3:
                    fight = new TimedFight(enemies, hacker);
                    break;
                default:
                    fight = new ConstrainedFight(enemies, hacker);
                    break;
            }
            _fight = fight;
            return fight;
        }

        private void EnemyAction()
        {
            var enemyActions = _fight.EnemyActions();

            foreach(var action in enemyActions)
            {
                AddEffect(action);
            }
            ResolveEffects();
            _fight.Turn++;
            string turnAnnouncement = $"Round {_fight.Turn} beginning.";
            _popupService.ShowToast(turnAnnouncement);
            //display toast for turn end ?

        }

        public IOptionList AfterOption()
        {
            optionHistory.Clear();
            ResolveEffects();
            switch(++_fight.TurnPhase)
            {
                case TurnPhase.Move:
                    var moves = _optionsService.GetMoveActions(_fight);
                    PreviousOptions = moves;
                    return moves;
                case TurnPhase.Action:
                    var actions = _optionsService.GetStandardActions(_fight);
                    PreviousOptions = actions;
                    return actions;
                case TurnPhase.Bonus:
                    if (!_fight.HasBonusAction)
                    {
                        return AfterOption();
                    }
                    var bonusACtions = _optionsService.GetBonusActions(_fight);
                    PreviousOptions = bonusACtions;
                    return bonusACtions;
                case TurnPhase.EndTurn:
                    var endTurn = _optionsService.GetEndTurn();
                    return endTurn;
                case TurnPhase.EnemyMove:
                    EnemyAction();
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
            foreach(var weapon in _fight.Player.Weapons)
            {
                if (weapon.Cooldown > 0) 
                {
                    weapon.Cooldown--;
                }
            }
        }

        private void HandleRolls(ICombatAction effect)
        {
            if(effect is IHaveAttackRoll attack)
            {
                var roll = attack.ShowAttackRoll();
                _popupService.ShowPopup(roll);
            }

            AddEffect(effect);
        }
        public async void AddEffect(ICombatAction effect)
        {
            
            
            var resolutions = effect.AddToCombatEffects(_fight);
            if(effect.MessageType != MessageType.None)
            {
                _logService.Log(effect.MessageType, effect.MessageArgs);
                await Task.Delay(200);
            }
            

            
            foreach (var resolution in resolutions)
            {
                if (resolution.MessageType != MessageType.None)
                {
                    _logService.Log(resolution.MessageType, resolution.MessageArgs);
                    await Task.Delay(200);
                }
            }
            //TODO fix delay
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
                        result = _optionsService.GetWeapons(_fight, false);
                        break;
                        //TODO figure out shooting with main hand and off hand
                    case "Attack":
                        //TODO handle melee combat
                    case "Stay":
                        var stay = new PlayerMovePass(_fight);
                        AddEffect(stay);
                        return AfterOption();
                    case "Do nothing":
                        var doNothing = new PlayerActionPass(_fight);
                        AddEffect(doNothing);
                        return AfterOption();
                    case "Items":
                        result = _optionsService.GetItems(_fight);
                        break;
                    case "Move":
                        var move = new PlayerGetCloser(_fight);
                        AddEffect(move);
                        return AfterOption();
                    case "End turn":
                        return AfterOption();
                }
                PreviousOptions = result;
                return result;

            }

            if (option is ITarget targetingEffect && !targetingEffect.AreaOfEffect)
            {

                CurrentTargetingEffect = targetingEffect;
                var targets = _optionsService.GetTargets(_fight, targetingEffect.MinRange, targetingEffect.MaxRange);
                
                return targets;


            }

            if(option is Dice dice)
            {
                dice.Roll();
                return AfterOption();
            }

            if(option is Weapon weapon)
            {
                CurrentTargetingEffect = new PlayerRangedAttack(_fight, weapon);
                var targets = _optionsService.GetTargets(_fight, weapon.MinRange, weapon.MaxRange);
                PreviousOptions = targets;
                return targets;
                //todo handle cooldown in turn resolution phase
            }

            if (option is Enemy target)
            {
                CurrentTargetingEffect.Targets.Add(target);
                var effect = (ICombatAction)CurrentTargetingEffect;


                AddEffect(effect);

                if(CurrentTargetingEffect is PlayerRangedAttack && _optionsService.CanShoot(_fight))
                {
                    return _optionsService.GetWeapons(_fight, true);
                }

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
