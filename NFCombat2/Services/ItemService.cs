using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Consumables;

namespace NFCombat2.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repository;
        public ItemService(ItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<Item>> GetAllItems()
        {
            
            var entities = await _repository.GetAll();

            var result = new List<Item>();
            foreach (var entity in entities)
            {
                Item item;
                switch(entity.Type)
                {
                    case Data.Enums.ItemType.Grenade:
                        item = new Grenade();
                        break;
                    case Data.Enums.ItemType.HealingPotion:
                        item = new HealingPotion();
                        break;
                    case Data.Enums.ItemType.MobileHealthKit:
                        item = new MobileHealthKit();
                        break;
                    case Data.Enums.ItemType.SaltPotion:
                        item = new SaltPotion();
                        break;
                    case Data.Enums.ItemType.StrengthPotion:
                        item = new StrengthPotion();
                        break;
                    case Data.Enums.ItemType.Wrench:
                    default:
                        item = new Wrench();
                        break;
                }
                result.Add(item);
            }
            return result;
        }
    }
}
