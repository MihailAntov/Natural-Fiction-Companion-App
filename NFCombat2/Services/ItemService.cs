using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items;
using System.Reflection;
using NFCombat2.Models.Items.ActiveEquipments;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Common.Enums;

namespace NFCombat2.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repository;
        private Dictionary<string, IAddable> _craftables;
        
        public ItemService(ItemRepository repository, IPlayerService playerService)
        {
            _repository = repository;
            LoadCraftables(playerService);
        }

        private async void LoadCraftables(IPlayerService playerService)
        {
            _craftables = new Dictionary<string, IAddable>();
            var craftables = await playerService.GetAllCraftables();
            foreach(var craftable in craftables)
            {
                _craftables.Add(craftable.Formula, craftable);
            }
        }

        public IAddable CheckFormula(string formula)
        {
            if (_craftables.ContainsKey(formula))
            {
                return _craftables[formula];
            }
            return null;
        }
    }
}
