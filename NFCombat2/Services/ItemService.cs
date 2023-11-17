using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items;
using System.Reflection;
using NFCombat2.Models.Items.ActiveEquipments;

namespace NFCombat2.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repository;
        public ItemService(ItemRepository repository)
        {
            _repository = repository;
        }

        public Task<ICollection<IAddable>> GetAllEquipment()
        {
            return GetAllByCategory(Data.Enums.ItemCategory.Equipment);
        }

        public Task<ICollection<IAddable>> GetAllItems()
        {
            return GetAllByCategory(Data.Enums.ItemCategory.Item);
        }

        public Task<ICollection<IAddable>> GetAllWeapons()
        {
            return GetAllByCategory(Data.Enums.ItemCategory.Weapon);
        }

        private async Task<ICollection<IAddable>> GetAllByCategory(Data.Enums.ItemCategory category)
        {
            
            var entities = await _repository.GetCategory(Data.Enums.ItemCategory.Item);

            var result = new List<IAddable>();
            foreach (var entity in entities)
            {
                IAddable item = ItemConverter(entity.Type, category);
                
                result.Add(item);
            }
            return result;
        }

        private IAddable ItemConverter(Data.Enums.ItemType type, Data.Enums.ItemCategory category)
        {
            string typeName = type.ToString();
            string[] itemLocations = new string[] { "Equipments", "Items", "Weapons", "ActiveEquipments" };
            
            
            foreach(var itemLocation in itemLocations)
            {
                string fullTypeName = $"NFCombat2.Models.Items.{itemLocation}.{typeName}, NFCombat2.Models";
                Type itemType = Type.GetType(fullTypeName);
                if(itemType != null)
                {
                    var item = Activator.CreateInstance(itemType);
                    return (Item)item;
                }
            }

            var item2 = Activator.CreateInstance(typeof(GrenadeLauncher));
            return (Item)item2;
            
        }
        
    }
}
