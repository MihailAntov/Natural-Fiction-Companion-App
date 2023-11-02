

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;
using NFCombat2.Models.Programs;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Services
{
    public class OptionsService : IOptionsService
    {
        
        public OptionsService()
        {
           
        }


        public IOptionList GetItems(Fight fight)
        {
            MobileHealthKit healthKit = new();
            Grenade grenade = new();
            var objects = new List<IAction>
            {
                healthKit, grenade
            };

            var result = objects.Select(o => new Option(o.Label, o)).ToList<IOption>();
            return new OptionList(result, true);
        }

        public IOptionList GetStandardActions(Fight fight)
        {
            var objects = new List<string>()
            {
                "Shoot",
                "Programs"
            };

            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false);
        }

        public IOptionList GetBonusActions(Fight fight)
        {
            var objects = new List<string>()
            {
                "Shoot",
                "Move",
                "Items"
            };

            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false);
        }

        public IOptionList GetMoveActions(Fight fight)
        {
            var objects = new List<string>()
            {
                "Move",
                "Items"
            };

            var result = objects.Select(o => new Option(o, o)).ToList<IOption>();
            return new OptionList(result, false);
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
            return new OptionList(result, true);
        }

        public IOptionList GetTargets(Fight fight, int minRange, int maxRange)
        {
            
            
            var objects = fight.Enemies
                .Where(e => e.Distance >= minRange && e.Distance <= maxRange)
                .ToList();

            var result = objects.Select(o => new Option(o.Name, o)).ToList<IOption>();
            return new OptionList(result, false);
        }

        



    }
}
