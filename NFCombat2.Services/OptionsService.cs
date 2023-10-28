

using NFCombat2.Common.Enums;
using NFCombat2.Models;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
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

        
        public ICollection<IAction> GetPrograms(Fight fight)
        {
            var result = new List<IAction>
            {
                new Program("Zap", (fight) => fight.Enemies.FirstOrDefault().Health -= 5),
                new Program("ZapZap", (fight) => fight.Enemies.FirstOrDefault().Health -= 10)
            };
            return result;
        }

        public ICollection<IAction> GetTargets(Fight fight, int? hand)
        {
            int weaponIndex = hand ?? 0;
            Weapon weapon = fight.Player.Weapons[0];
            return fight.Enemies
                .Where(e => e.Distance <= weapon.Range)
                .Select(e=> new PlayerRangedAttack(fight)
                {
                    Label = e.Name,
                    Target = e
                }).ToList<IAction>();    
        }

        public ICollection<IAction> GetOptions(Fight fight, string category)
        {
            //todo remove temporary items and programs

            var result = new List<IAction>();
            switch (category) 
            {
                case "Items":
                    result = GetItems(fight) as List<IAction>;
                    
                    break;
                case "Programs":
                    result = GetPrograms(fight) as List<IAction>;
                    break;
                case "Shoot":
                    result = GetTargets(fight, null) as List<IAction>;
                    break;
                case "ShootWithOffHand":
                    result = GetTargets(fight, 1) as List<IAction>;
                    break;
            }

            return result;
        }



    }
}
