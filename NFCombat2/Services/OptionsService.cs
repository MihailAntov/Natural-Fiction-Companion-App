

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;
using NFCombat2.Contracts;

namespace NFCombat2.Services
{
    public class OptionsService : IOptionsService
    {
        
        public OptionsService()
        {
           
        }


        public IOptionList GetItems(Fight fight)
        {
            var result = fight.Player.Consumables.Select(o => new Option(o.Label, o)).ToList<IOption>();
            return new OptionList(result, true, true) {Label = "Choose item to use" };
        }

        public IOptionList GetStandardActions(Fight fight)
        {
            var objects = new List<string>();

            if (CanShoot(fight))
            {
                objects.Add("Shoot");
            }

            if(CanAttack(fight))
            {
                objects.Add("Attack");
            }

            objects.Add("Do nothing");


            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false, false) { Label = "Choose standard action" };
        }

        public IOptionList GetBonusActions(Fight fight)
        {
            var objects = new List<string>();

            if (CanShoot(fight))
            {
                objects.Add("Shoot");
            }

            if (CanAttack(fight))
            {
                objects.Add("Attack");
            }

            if (CanUseProgram(fight))
            {
                objects.Add("Program");
            }


            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false, false) { Label = "Choose bonus to use" };
        }

        public IOptionList GetMoveActions(Fight fight)
        {
            var objects = new List<string>();

            if (CanMove(fight))
            {
                objects.Add("Move");
            }

            if (HasItems(fight))
            {
                objects.Add("Items");
            }

            objects.Add("Stay");

            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false, false) { Label = "Choose move action" };
        }


        public IOptionList GetWeapons(Fight fight, bool alreadyShot)
        {
            var weapons = fight.Player.Weapons
                .Where(w => w.RemainingCooldown < w.ShotsPerTurn && fight.Enemies.Any(e => e.Distance >= w.MinRange && e.Distance <= w.MaxRange))
                .Select(w => new Option(w.Label, w))
                .ToList<IOption>();
            var options =  new OptionList(weapons, true, !alreadyShot) { Label = "Choose a weapon to shoot with" };
            if(alreadyShot)
            {
                options.Options.Add(new Option("Done",new PlayerActionPass(fight)));
            }
            return options;
        }

        public IOptionList GetPrograms(Fight fight)
        {
            var program1 = new Program("Zap Bonus Action", "Нанася 1 зар щети на избран опонент. Можете да предприемете допълнително действие.", fight.Player) { Cost = 1 };
             program1.Effects.Add(new DamageProgramEffect(1, 0, program1));
            program1.Effects.Add(new BonusActionProgramEffect());

            var program2 = new Program("ZapZap", "Нанася 2 зара щети + 2 на избран опонент.", fight.Player) { Cost = 2 };
            program2.Effects.Add(new DamageProgramEffect(2, 2,program2));
            
            var objects = new List<IAction>
            {
                program1,
                program2  
            };


            var result = objects.Select(o => new Option(o.Label, o)).ToList<IOption>();
            return new OptionList(result, true, true) { Label = "Choose which program to use" };
        }

        public IOptionList GetTargets(Fight fight, int minRange, int maxRange)
        {
            var objects = fight.Enemies
                .Where(e => e.Distance >= minRange && e.Distance <= maxRange)
                .ToList();

            var result = objects.Select(o => new Option(o.Name, o)).ToList<IOption>();
            return new OptionList(result, false,true) { Label = "Choose which enemy to shoot" };
        }
        public IOptionList GetEndTurn()
        {
            var option = new Option("End turn", "End turn");
            var result = new OptionList() { Label = "End turn", CanGoBack = false, IsInfoNeeded = false, Options = new List<IOption> { option } };
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

            return true;
        }

        private bool CanAttack(Fight fight)
        {
            return fight.Enemies.Any(e => e.Distance == 0);
        }

        private bool CanMove(Fight fight)
        {
            return !CanAttack(fight);
        }

        public bool HasItems(Fight fight)
        {
            return fight.Player.Consumables.Any();
        }

        public bool CanUseProgram(Fight fight)
        {
            if(fight.Player is Hacker)
            {
                return true;
            }
            return false;
        }

        

       
    }
}
