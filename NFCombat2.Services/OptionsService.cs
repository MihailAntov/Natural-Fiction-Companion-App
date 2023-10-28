

using NFCombat2.Common.Enums;
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


        public ICollection<IAction> GetItems(Fight fight)
        {
            var result = new List<IAction>
            {
                new Consumable("Health kit", (fight) => { fight.Player.Health += 10; }),
                new Consumable("Grenade", (fight) =>
                {
                    foreach (var enemy in fight.Enemies)
                    {
                        enemy.Health -= 5;
                    }
                })
            };
            return result;
        }

        public ICollection<string> GetCategories(Fight fight)
        {
            return new List<string>()
            {
                "Shoot",
                "Move",
                "Programs",
                "Items"
            };
        }

        public ICollection<string> GetBonusCategories(Fight fight)
        {
            return new List<string>()
            {
                "Shoot",
                "Move",
                "Items"
            };
        }

        
        public ICollection<IAction> GetPrograms(Fight fight)
        {
            var program1 = new Program("Zap Bonus Action");
            program1.Effects.Append(new DamageEffect(1, 0, program1));
            program1.Effects.Append(new BonusActionEffect());

            var program2 = new Program("ZapZap");
            program2.Effects.Append(new DamageEffect(2, 2,program2));
            
            var result = new List<IAction>
            {
                program1,
                program2  
            };
            return result;
        }

        public ICollection<Enemy> GetTargets(Fight fight, int minRange, int maxRange)
        {
            return fight.Enemies
                .Where(e => e.Distance >= minRange && e.Distance <= maxRange)
                .ToList(); 
        }

        



    }
}
