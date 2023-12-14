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
using NFCombat2.Models.Items;
using NFCombat2.Models.SpecOps;
using System.Runtime.CompilerServices;
using NFCombat2.ViewModels;
using NFCombat2.Views;

namespace NFCombat2.Services
{
    public class FightService : IFightService, INotifyPropertyChanged
    {
        private Fight _fight;
        private bool _accepted = false;
        public bool Accepted { get { return _accepted; } 
            set
            {
                if(_accepted!= value)
                {
                    _accepted = value;
                    OnPropertyChanged(nameof(Accepted));
                }
            }
        }

        

        
        private readonly ILogService _logService;
        private readonly IOptionsService _optionsService;
        private readonly IPopupService _popupService;
        private readonly IAccuracyService _accuracyService;
        private readonly FightRepository _fightRepository;
        private readonly IPlayerService _playerService;
        private readonly INameService _nameService;
        //private readonly ISeederService _seederService;
        public FightService(
            ILogService logService, 
            IOptionsService optionsService, 
            IPopupService popupService, 
            IAccuracyService accuracyService, 
            FightRepository fightRepository,
            IPlayerService playerService,
            INameService nameService
            )
        {
            _logService = logService;
            _optionsService = optionsService;
            _popupService = popupService;
            _accuracyService = accuracyService;
            _fightRepository = fightRepository;
            _playerService = playerService;
            _nameService = nameService;
            
        }

        public ITarget CurrentTargetingEffect {get; set;}
        public IHaveModes CurrentModeEffect { get; set; }

        private List<ICombatAction> _delayedActions = new List<ICombatAction>();

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

        public event PropertyChangedEventHandler PropertyChanged;


        public async void AcceptFightResults()
        {
            await _playerService.SavePlayer();
            Accepted = true;
            
        }

        public async void RejectFightResults()
        {
            
            var player = await _playerService.GetPlayerById(_fight.Player.Id);
            await _playerService.SwitchToPlayer(player);
            Accepted = true;
        }

        public async Task<Fight> GetFightByEpisodeNumber(int episodeNumber)
        {

            var enemies = new List<Enemy>();

            var targetDummy = new Enemy()
            {
                Name = "Enemy 1",
                Health = 10,
                Distance = 3,
                Speed = 2,
                Range = 10,
                DamageDice = 1

            };

            var targetDummy2 = new Enemy()
            {
                Name = "Enemy 2",
                Health = 10,
                Distance = 5,
                Speed = 2,
                Range = 15,
                DamageDice = 1
            };
            enemies.Add(targetDummy);

            var hacker = new Player() { Name = "Istvan", Class = PlayerClass.Hacker };
            var specOps = new Player() { Name = "Hackerman", Class = PlayerClass.Hacker };
            //hacker.Weapons.Add(new PlasmaRapier());
            //hacker.Weapons.Add(new Weapon() { Label = "Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1 });
            //hacker.Weapons.Add(new Weapon() { Label = "Sniper Rifle", MinRange = 5, MaxRange = 20, DamageDice = 1 });
            hacker.Activatables.Add(new HandGrenade());
            //specOps.Weapons.Add(new Weapon() { Label = "Pistol", MinRange = 0, MaxRange = 8, DamageDice = 1, Accuracy = Accuracy.C });
            specOps.Activatables.Add(new HandGrenade());
            specOps.Equipment.Add(new TacticalGlasses());
            specOps.Equipment.Add(new PortableSurgicalLaser());
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
                case 4:
                    fight = new TentacleFight(enemies);
                    fight.Player = _playerService.CurrentPlayer;
                    break;
                default:
                    fight = new ConstrainedFight(enemies);
                    fight.Player = hacker;
                    break;
            }

            _fight = fight;
            Accepted = false;
            fight.SetUp();
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
                var followup = await modifier.Modify(resolution);
                if (followup.Any())
                {
                    foreach(var action in followup)
                    {
                        
                        _delayedActions.Add(action);
                    }
                }
            }
        }
        private async void FinishCombat(FightResult result)
        {
            
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            var viewModel = new FightResultPopupViewModel(_fight, _nameService, taskCompletionSource);
            var popup = new FightResultPopupView(viewModel);
            _popupService.ShowPopup(popup);
            var output =  await taskCompletionSource.Task;
            await popup.CloseAsync();
            foreach(var effect in _fight.TemporaryEffects)
            {
                effect.Invoke();
            }
            _fight.TemporaryEffects.Clear();
            if (output)
            {
                AcceptFightResults();
            }
            else
            {
                RejectFightResults();
            }



        }

        public async Task<IOptionList> AfterOption()
        {
            
            optionHistory.Clear();
            await ResolveEffects();
            await HandleHealthLoss();
            _fight.CheckWinCondition();
            if (_fight.Result != FightResult.None)
            {
                FinishCombat(_fight.Result);
                return new OptionList();
            }

            switch (++_fight.TurnPhase)
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
            if (_delayedActions.Any())
            {
                foreach(var action in _delayedActions)
                {
                    
                    await HandleRolls(action);
                    
                }
                _delayedActions.Clear();
            }

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

            await HandleHealthLoss();
            
        }

        private async Task HandleHealthLoss()
        {
            await HandlePlayerHealthLoss();
            await HandleEnemyHealthLoss();
            
            
        }

        private async Task HandlePlayerHealthLoss()
        {
            if (!_fight.Player.HealthHasChanged)
            {
                return;
            }

            _fight.Player.HealthHasChanged = false;
            if (_fight.Player.Class == PlayerClass.SpecOps)
            {
                await HandleTechniques(_fight.Player);
            }

            if (_fight.Player.Health < _fight.Player.MinHealth)
            {
                _fight.Result = FightResult.Lost;
            }
        }

        private async Task HandleEnemyHealthLoss()
        {
            _fight.Enemies = _fight.Enemies.Where(e => e.Health > 0).ToList();
            
            return;
        }

        private async Task HandleTechniques(Player player)
        {

        }

        private async Task HandleRolls(ICombatAction effect)
        {
            bool canReroll = _playerService.CurrentPlayer.Class == PlayerClass.SpecOps;
            if(effect is IHaveAttackRoll attack && !attack.AlwaysHits)
            {
                var taskCompletion = await _popupService.ShowDiceAttackRollPopup(attack, canReroll);
                await taskCompletion.Task;
            }

            if(effect is IHaveRolls rollEffect && rollEffect.RollsResult.Dice.Count > 0)
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
                    if (attack.AlwaysHits)
                    {
                        resolutions = effect.AddToCombatEffects(_fight);
                    }
                    else
                    {
                        var result = _accuracyService.Hits(attack, _fight);
                        switch (result)
                        {
                            case AttackResult.Miss:
                                resolutions = attack.AddMissToCombatResolutions(_fight);
                                break;
                            case AttackResult.Hit:
                                resolutions = effect.AddToCombatEffects(_fight);
                                break;
                            case AttackResult.Crit:
                                resolutions = attack.AddCritToCombatResolutions(_fight);
                                break;
                        }
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

            if(option is IHaveModes itemWithModes && itemWithModes.Mode == null)
            {
                CurrentModeEffect = itemWithModes;
                var options = _optionsService.GetModes(itemWithModes);
                return options;
            }

            if(option is IMode mode)
            {
                CurrentModeEffect.Mode = mode;
                var effect = (ICombatAction)CurrentModeEffect;
                return await ProcessChoice(effect);
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
                if (weapon.AreaOfEffect)
                {
                    var areaOfEffectAttack = new PlayerRangedAttack(_fight, weapon);
                    areaOfEffectAttack.Targets = targets.Options.Select(t => (Enemy)t.Content).ToList();
                    await HandleRolls(areaOfEffectAttack);
                    return await AfterOption();
                }

                PreviousOptions = targets;
                return targets;
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
                if(option is ICombatActiveItem item && item.IsConsumable)
                {
                    item.Quantity--;
                    if(item.Quantity == 0)
                    {
                        _fight.Player.Items.Remove((Item)item);
                        _fight.Player.ExtraItems.Remove((Item)item);
                        if(item is Equipment)
                        {
                            _fight.Player.Equipment.Remove((Equipment)item);
                        }
                    }
                }
                return await AfterOption();

            }

            return _optionsService.GetMoveActions(_fight);  
        }
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
