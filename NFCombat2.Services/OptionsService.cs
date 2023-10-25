

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

        public ICollection<string> GetCategories(Fight fight)
        {
            return new List<string>() { "Shoot", "Item", "Move in" };
        }

        public ICollection<IMoveAction> GetItems(Fight fight)
        {
            return new List<IMoveAction>() { new Consumable() };
        }

        public ICollection<IStandardAction> GetPrograms(Fight fight)
        {
            return new List<IStandardAction>();
        }
    }
}
