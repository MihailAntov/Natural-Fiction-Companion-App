

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;
using NFCombat2.Contracts;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Equipments;


namespace NFCombat2.Services
{
    public class OptionsService : IOptionsService
    {
        private readonly IPlayerService _playerService;
        private readonly INameService _nameService;
        public OptionsService(IPlayerService playerService, INameService nameService)
        {
           _playerService = playerService;
            _nameService = nameService;
        }


        public IOptionList GetItems(Fight fight)
        {
            var result = fight.Player.Activatables
                .Where(a=> !a.UnavailableForRestOfCombat)
                .Select(o => new Option(o.Name, o)).ToList<IOption>();
            return new OptionList(result, true, true) {Label = "Choose item to use" };
        }

        public IOptionList GetStandardActions(Fight fight)
        {
            //var objects = new List<string>();
            var objects = new List<OptionType>();

            if (CanShoot(fight))
            {
                objects.Add(OptionType.Shoot);
            }

            if(CanAttack(fight))
            {
                if(fight is HazardFight hazard)
                {
                    objects.Add(OptionType.SwampAttack);
                }
                else if (fight is SkillCheckFight skillCheck)
                {
                    objects.Add(OptionType.StrengthCheckAttack);
                }
                else
                {
                    objects.Add(OptionType.Attack);
                }
            }

            if (CanUseProgram(fight))
            {
                objects.Add(OptionType.Program);    
            }

            if(fight.Player.Class == PlayerClass.SpecOps && !fight.UsedAdrenalineThisTurn)
            {
                objects.Add(OptionType.AdrenalineRush);
            }

            if (fight.Player.Class == PlayerClass.SpecOps && fight.Player.Techniques.Any(t => t.Value != null && t.Value.Type == TechniqueType.Backflip) && !fight.UsedBackflipThisFight)
            {
                objects.Add(OptionType.Backflip);
            }

            objects.Add(OptionType.DoNothing);

            var result = new List<IOption>();
            foreach (var obj in objects)
            {
                CheckType type = CheckType.None;
                if (fight is SkillCheckFight checkFight && obj == OptionType.StrengthCheckAttack)
                {
                    type = checkFight.CheckType;
                }else if (fight is HazardFight hazardFight && obj == OptionType.SwampAttack)
                {
                    type = hazardFight.CheckType;
                }

                if(obj == OptionType.AdrenalineRush)
                {
                    string adrenalineLabel = _nameService.Option(obj, type, fight.AdrenalineCost);
                    result.Add(new Option(adrenalineLabel, obj));
                    continue;
                }

                string label = _nameService.Option(obj, type);
                result.Add(new Option(label, obj));
            }
            return new OptionList(result, false, false) { Label = "Choose standard action" };
            //TODO : involve converter service to get name of option
        }

        public IOptionList GetBonusActions(Fight fight)
        {
            var objects = new List<OptionType>();

            if (CanShoot(fight))
            {
                //objects.Add("Shoot");
                objects.Add(OptionType.Shoot);
            }

            if (CanAttack(fight))
            {
                //objects.Add("Attack");
                objects.Add(OptionType.Attack);
            }

            //if (CanUseProgram(fight))
            //{
            //    //objects.Add("Program");
            //    objects.Add(OptionType.Program);
            //}

            if (fight.Player.Class == PlayerClass.SpecOps && fight.Player.Techniques.Any(t => t.Value != null && t.Value.Type == TechniqueType.Backflip) && !fight.UsedBackflipThisFight)
            {
                objects.Add(OptionType.Backflip);
            }

            //TODO: involve converter service to get name of option
            var result = objects.Select(o => new Option(o.ToString(), o)).ToList<IOption>();
            return new OptionList(result, false, false) { Label = "Choose bonus to use" };
        }

        public IOptionList GetMoveActions(Fight fight)
        {
            var objects = new List<OptionType>();
            //var objects = new List<string>();

            if (CanMove(fight) && fight.Type != FightType.Escape)
            {
                objects.Add(OptionType.Move);
            }

            if (HasItems(fight))
            {
                objects.Add(OptionType.Item);
            }

            if(fight.Type == FightType.Escape)
            {
                objects.Add(OptionType.SkipTurn);
            }

            if (fight.Player.Class == PlayerClass.SpecOps && !fight.UsedAdrenalineThisTurn)
            {
                objects.Add(OptionType.AdrenalineRush);
            }

            if (fight.Player.Class == PlayerClass.SpecOps && fight.Player.Techniques.Any(t=> t.Value != null && t.Value.Type == TechniqueType.Backflip) && !fight.UsedBackflipThisFight)
            {
                objects.Add(OptionType.Backflip);
            }

            objects.Add(OptionType.Stay);

            //TODO : involve converter service to get name of option
            CheckType type = CheckType.None;
            var result = new List<IOption>();
            foreach(var obj in objects)
            {
                if(obj == OptionType.AdrenalineRush)
                {
                    result.Add(new Option(_nameService.Option(obj, type, fight.AdrenalineCost),obj));
                    continue;
                }

                result.Add(new Option(_nameService.Option(obj), obj));
            }
            return new OptionList(result, false, false) { Label = "Choose move action" };
        }


        public IOptionList GetWeapons(Fight fight, bool alreadyShot)
        {
            var weapons = fight.Player.Weapons
                .Where(w => w.RemainingCooldown < w.ShotsPerTurn && fight.Enemies.Any(e => e.Distance >= w.MinRange && e.Distance <= w.EffectiveMaxRange))
                .Select(w => new Option(w.Name, w))
                .ToList<IOption>();
            var options =  new OptionList(weapons, true, !alreadyShot) { Label = "Choose a weapon to shoot with" };
            if(alreadyShot)
            {
                options.Options.Add(new Option(OptionType.Done.ToString(),new PlayerActionPass(fight)));
            }
            return options;
        }

        public IOptionList GetPrograms(Fight fight)
        {
            

            
            var result = new OptionList(new List<IOption>(), true, true) { Label = "Choose which program to use" };
            result.Options.Add(new Option("Manual",new ManualProgramCast()));
            
            var knownPrograms = fight.Player.Programs;
            foreach(var program in knownPrograms)
            {
                result.Options.Add(new Option(program.Name, program));
            }
            return result;

        }

        public IOptionList GetTargets(Fight fight, int minRange, int maxRange)
        {
            var objects = fight.Enemies
                .Where(e => e.Distance >= minRange && e.Distance <= maxRange)
                .ToList();
            string label = maxRange == 0 ? "Choose which enemy to attack" : "Choose which enemy to shoot";

            var result = objects.Select(o => new Option(o.Name, o)).ToList<IOption>();
            return new OptionList(result, false,true) { Label = label };
        }
        public IOptionList GetEndTurn(Fight fight)
        {

            var end = new Option("End turn", OptionType.EndTurn);
            var options = new List<IOption>() { end };
            if(_playerService.CurrentPlayer.Class == PlayerClass.SpecOps && !fight.UsedAdrenalineThisTurn)
            {
                options.Add(new Option(_nameService.Option(OptionType.AdrenalineRush, CheckType.None, fight.AdrenalineCost), OptionType.AdrenalineRush));
            }
            var result = new OptionList() { Label = "End turn", CanGoBack = false, IsInfoNeeded = false, Options = options };
            return result;
        }

        public bool CanShoot(Fight fight)
        {
            if (CanAttack(fight))
            {
                return false;
            }

            if (!GetWeapons(fight, false).Options.Any())
            {
                return false;
            }

            if(fight.Type == FightType.Virtual)
            {
                return false;
            }

            return true;
        }

        private bool CanAttack(Fight fight)
        {
            if(fight.Type == FightType.Virtual)
            {
                return false;
            }
            return fight.Enemies.Any(e => e.Distance == 0);
        }

        private bool CanMove(Fight fight)
        {
            if(fight is StationaryFight)
            {
                return false;
            }
            return !CanAttack(fight);
        }

        public bool HasItems(Fight fight)
        {
            if(fight.Type == FightType.Virtual)
            {
                return false;
            }
            return fight.Player.Activatables.Any();
        }

        public bool CanUseProgram(Fight fight)
        {
            
            if(fight.AllowsPrograms && fight.Player.Class == PlayerClass.Hacker)
            {
                return true;
            }
            return false;
        }

        public ICollection<IModificationOption> GetModificationOptions(WeaponModification modification)
        {
            var player = _playerService.CurrentPlayer;
            var result = new List<IModificationOption>();

            foreach(var weapon in player.Weapons.Where(w=>w.MaxRange > 0 && !w.Modifications.Any(mod=>mod.ItemType == modification.ItemType)))
            {
                result.Add(new ModificationOption()
                {
                    Image = weapon.Image,
                    Name = weapon.Name,
                    ToBeAttachedTo = weapon.Hand == Hand.MainHand ? AttachedTo.MainHand : AttachedTo.OffHand
                });

                
            }

            if (modification.AttachedTo != AttachedTo.None)
            {
                result.Add(new ModificationOption()
                {
                    Image = "none",
                    Name = "Unequip",
                    ToBeAttachedTo = AttachedTo.None
                });
            }

            return result;
        }

        public IOptionList GetModes(IHaveModes itemWithModes)
        {
            List<IOption> options = new List<IOption>();
            foreach(var mode in itemWithModes.Modes) 
            {
                mode.Name = _nameService.ModeName(mode.ItemMode);
                options.Add(new Option(mode.Name, mode));
            }

            return new OptionList()
            {
                Label = "Choose mode",
                Options = options
            };
        }

        public IOptionList GetAdrenalineActions(Fight fight)
        {
            var objects = new List<OptionType>();
            if (CanMove(fight) && fight.Type != FightType.Escape)
            {
                objects.Add(OptionType.Move);
            }

            if (HasItems(fight))
            {
                objects.Add(OptionType.Item);
            }

            if (CanShoot(fight))
            {
                objects.Add(OptionType.Shoot);
            }

            if (CanAttack(fight))
            {
                if (fight is HazardFight hazard)
                {
                    objects.Add(OptionType.SwampAttack);
                }
                else if (fight is SkillCheckFight skillCheck)
                {
                    objects.Add(OptionType.StrengthCheckAttack);
                }
                else
                {
                    objects.Add(OptionType.Attack);
                }
            }

            objects.Add(OptionType.DoNothing);
            List<IOption> results = new List<IOption>();
            foreach(var obj in objects)
            {
                CheckType type = CheckType.None;
                if (fight is SkillCheckFight checkFight && obj == OptionType.StrengthCheckAttack)
                {
                    type = checkFight.CheckType;
                }
                else if (fight is HazardFight hazardFight && obj == OptionType.SwampAttack)
                {
                    type = hazardFight.CheckType;
                }

                if (obj == OptionType.AdrenalineRush)
                {
                    string adrenalineLabel = _nameService.Option(obj, type, fight.AdrenalineCost);
                    results.Add(new Option(adrenalineLabel, obj));
                    continue;
                }

                string label = _nameService.Option(obj, type);
                results.Add(new Option(label, obj));
            }
            return new OptionList(results, false, false) { Label = "Choose extra action" };
        }
    }
}
