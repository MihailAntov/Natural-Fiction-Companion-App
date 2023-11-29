using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Actions;
using NFCombat2.Common.Enums;
using System.ComponentModel;
using CommunityToolkit.Maui.Alerts;
using NFCombat2.Common.Helpers;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Items.ActiveEquipments;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.SpecOps;

namespace NFCombat2.Services
{
    public class FightService : IFightService
    {
        private Fight _fight;
        
        private readonly ILogService _logService;
        private readonly IOptionsService _optionsService;
        private readonly IPopupService _popupService;
        private readonly IAccuracyService _accuracyService;
        private readonly FightRepository _fightRepository;
        private readonly IPlayerService _playerService;
        //private readonly ISeederService _seederService;
        public FightService(
            ILogService logService, 
            IOptionsService optionsService, 
            IPopupService popupService, 
            IAccuracyService accuracyService, 
            FightRepository fightRepository,
            IPlayerService playerService
            /*ISeederService seederService*/)
        {
            _logService = logService;
            _optionsService = optionsService;
            _popupService = popupService;
            _accuracyService = accuracyService;
            _fightRepository = fightRepository;
            _playerService = playerService;
            //if (!_fightRepository.Seeded)
            //{
            //    _seederService = seederService;
                
            //    _seederService.SeedFights();
            //}
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
                Name = "Enemy 1",
                Health = 10,
                Distance = 10,
                Speed = 2,
                Range = 10,
                DamageDice = 1

            };

            var targetDummy2 = new Enemy()
            {
                Name = "Enemy 2",
                Health = 10,
                Distance = 15,
                Speed = 2,
                Range = 15,
                DamageDice = 8
            };
            enemies.Add(targetDummy);

            var hacker = new Player() { Name = "Istvan", Class = PlayerClass.Hacker };
            var specOps = new Player() { Name = "Hackerman", Class = PlayerClass.Hacker };
            //hacker.Weapons.Add(new PlasmaRapier());
            //hacker.Weapons.Add(new Weapon() { Label = "Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1 });
            //hacker.Weapons.Add(new Weapon() { Label = "Sniper Rifle", MinRange = 5, MaxRange = 20, DamageDice = 1 });
            hacker.Consumables.Add(new HandGrenade());
            //specOps.Weapons.Add(new Weapon() { Label = "Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1, Accuracy = Accuracy.C });
            specOps.Consumables.Add(new HandGrenade());
            specOps.Equipment.Add(new TacticalGlasses());
            specOps.Techniques.Add(new Feint());
            Fight fight;

            switch (episodeNumber)
            {
                case 0:
                    //fight = new Fight(enemies, hacker);
                    fight = new Fight(enemies);
                    fight.Player = _playerService.CurrentPlayer;
                    enemies.Add(targetDummy2);
                    break;
                case 1:
                    fight = new ChaseFight(enemies);
                    fight.Player = specOps;
                    break;
                case 2:
                    fight = new SkillCheckFight(enemies);
                    fight.Player = hacker;
                    break;
                case 3:
                    fight = new TimedFight(enemies);
                    fight.Player = hacker;
                    break;
                default:
                    fight = new ConstrainedFight(enemies);
                    fight.Player = hacker;
                    break;
            }

            _fight = fight;
            return _fight;
        }

        private async Task EnemyAction()
        {
            var enemyActions = _fight.EnemyActions();
            foreach(var action in enemyActions)
            {
                await HandleRolls(action);
            }
            await ResolveEffects();
            _fight.Turn++;
            string turnAnnouncement = $"Round {_fight.Turn} beginning.";
            _popupService.ShowToast(turnAnnouncement);
            

        }

        private async Task ModifyAction(ICombatAction action)
        {
            foreach (IModifyAction modifier in _fight.Player.ActionModifiers)
            {
                await modifier.Modify(action);
            }
        }

        private async Task ModifyResolution(ICombatResolution resolution)
        {
            foreach (IModifyResolution modifier in _fight.Player.ResolutionModifiers)
            {
                await modifier.Modify(resolution);
            }
        }

        public async Task<IOptionList> AfterOption()
        {
            optionHistory.Clear();
            await ResolveEffects();
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
                        return await AfterOption();
                    }
                    var bonusACtions = _optionsService.GetBonusActions(_fight);
                    PreviousOptions = bonusACtions;
                    return bonusACtions;
                case TurnPhase.EndTurn:
                    var endTurn = _optionsService.GetEndTurn();
                    return endTurn;
                case TurnPhase.EnemyMove:
                    await EnemyAction();
                    _fight.TurnPhase = TurnPhase.None;
                    return await AfterOption();
                
                default:
                    throw new InvalidEnumArgumentException(nameof(TurnPhase));
            }
        }

        public async Task ResolveEffects()
        {
            while(_fight.Effects.Count > 0)
            {
                var effect = _fight.Effects.Dequeue();
                await effect.Resolve(_fight);
                
            }

            foreach(var weapon in _fight.Player.Weapons)
            {
                if (weapon.RemainingCooldown > 0) 
                {
                    weapon.RemainingCooldown -= weapon.ShotsPerTurn;
                }
            }
        }

        private async Task HandleRolls(ICombatAction effect)
        {
            bool canReroll = _playerService.CurrentPlayer.Class == PlayerClass.SpecOps;
            if(effect is IHaveAttackRoll attack)
            {
                var taskCompletion = await _popupService.ShowDiceAttackRollPopup(attack, canReroll);
                await taskCompletion.Task;
            }

            if(effect is IHaveRolls rollEffect)
            {
                var taskCompletion = await _popupService.ShowDiceRollsPopup(rollEffect, canReroll);
                await taskCompletion.Task;
            }

            if(effect is IHaveOpposedRolls meleeCombat)
            {
                var attackCompletion = await _popupService.ShowMeleeCombatRollsPopup(meleeCombat, canReroll);
                await attackCompletion.Task;
                
            }

            await ModifyAction(effect);
            await AddEffect(effect);
        }
        public async Task AddEffect(ICombatAction effect)
        {
            
            IList<ICombatResolution> resolutions = new List<ICombatResolution>();
            if(effect is IHaveAttackRoll attack)
            {
                //if attack, check for remaining crits from program effects 
                if(_fight.RemainingCrits > 0)
                {
                    resolutions = attack.AddCritToCombatResolutions(_fight);
                    _fight.RemainingCrits--;
                }
                //otherwise proceed to roll for attack
                else
                {
                    var result = _accuracyService.Hits(attack, _fight);
                    switch (result)
                    {
                        case AttackResult.Miss:
                            resolutions = attack.AddMissToCombatResolutions(_fight);
                            break;
                        case AttackResult.Hit:
                            resolutions = attack.AddCritToCombatResolutions(_fight);
                            break;
                        case AttackResult.Crit:
                            resolutions = attack.AddCritToCombatResolutions(_fight);
                            break;
                    }
                }
            }
            else
            {
                //if not an attack, process effect
                resolutions = effect.AddToCombatEffects(_fight);
            }

            foreach (var resolution in resolutions)
            {
                await ModifyResolution(resolution);

            }

            if (effect.MessageType != MessageType.None)
            {
                await _logService.Log(effect.MessageType, effect.MessageArgs);
            }



            foreach (var resolution in resolutions)
            {
                if (resolution.MessageType != MessageType.None)
                {
                    await _logService.Log(resolution.MessageType, resolution.MessageArgs);
                }
            }


        }

        

        public async Task<IOptionList> ProcessChoice(object option)
        {
            IOptionList result = new OptionList();

            if (option is OptionType category)
            {
                switch (category)
                {
                    case OptionType.Program:

                        result = _optionsService.GetPrograms(_fight);
                        break;
                    case OptionType.Shoot:
                        result = _optionsService.GetWeapons(_fight, false);
                        break;
                    case OptionType.Attack:
                        result = _optionsService.GetTargets(_fight, 0, 0);
                        break;
                    case OptionType.Stay:
                        var stay = new PlayerMovePass(_fight);
                        await AddEffect(stay);
                        return await AfterOption();
                    case OptionType.DoNothing:
                        var doNothing = new PlayerActionPass(_fight);
                        await AddEffect(doNothing);
                        return await AfterOption();
                    case OptionType.Item:
                        result = _optionsService.GetItems(_fight);
                        break;
                    case OptionType.Move:
                        var move = new PlayerGetCloser(_fight);
                        await AddEffect(move);
                        return await AfterOption();
                    case OptionType.EndTurn:
                        return await AfterOption();
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
                return await AfterOption();
            }

            if(option is Weapon weapon)
            {
                CurrentTargetingEffect = new PlayerRangedAttack(_fight, weapon);
                var targets = _optionsService.GetTargets(_fight, weapon.MinRange, weapon.EffectiveMaxRange);
                PreviousOptions = targets;
                return targets;
                //todo handle cooldown in turn resolution phase
            }

            if (option is Enemy target)
            {
                if(target.Distance == 0)
                {
                    var meleeAttack = new PlayerMeleeAttack(_fight, target);
                    await HandleRolls(meleeAttack);
                    return await AfterOption();
                    
                }


                CurrentTargetingEffect.Targets.Add(target);
                var effect = (ICombatAction)CurrentTargetingEffect;
                await HandleRolls(effect);

                if (CurrentTargetingEffect is PlayerRangedAttack && _optionsService.CanShoot(_fight))
                {
                    return _optionsService.GetWeapons(_fight, true);
                }

                return await AfterOption();

            }


            if (option is ICombatAction combatEffect)
            {
                await HandleRolls(combatEffect);
                //AddEffect(combatEffect);
                return await AfterOption();

            }

            return _optionsService.GetMoveActions(_fight);  
        }
    }
}
