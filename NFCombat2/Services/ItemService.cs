using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items;
using System.Reflection;
using NFCombat2.Models.Items.ActiveEquipments;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Common.Enums;
using static NFCombat2.Common.AppConstants.ItemNames;

namespace NFCombat2.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repository;
        private readonly IPlayerService _playerService;
        private Dictionary<ItemType, Weapon> _weapons;
        private Dictionary<ItemType, Item> _genericItems;
        public ItemService(ItemRepository repository, IPlayerService playerService)
        {
            _repository = repository;
            _weapons = WeaponDictionary();
            _genericItems = ItemDictionary();
            _playerService = playerService;

        }

        public Task<ICollection<IAddable>> GetAllEquipment()
        {
            return GetAllByCategory(ItemCategory.Equipment);
        }

        public Task<ICollection<IAddable>> GetAllItems()
        {
            return GetAllByCategory(ItemCategory.Item);
        }

        public Task<ICollection<IAddable>> GetAllWeapons()
        {
            return GetAllByCategory(ItemCategory.Weapon);
        }

        private async Task<ICollection<IAddable>> GetAllByCategory(ItemCategory category)
        {

            var entities = await _repository.GetCategory(category);

            var result = new List<IAddable>();
            foreach (var entity in entities)
            {
                IAddable item = ItemConverter(entity.Type, category);

                result.Add(item);
            }
            return result;
        }

        private IAddable ItemConverter(ItemType type, ItemCategory category)
        {
            if (category == ItemCategory.Weapon)
            {
                return ConvertWeapon(type);
            }
            if (category == ItemCategory.Item || category == ItemCategory.Equipment)
            {
                return ConvertItemAndEquipment(type);
            }

            return ConvertGenericItem(type);


        }

        private IAddable ConvertItemAndEquipment(ItemType type)
        {
            string typeName = type.ToString();
            string[] itemLocations = new string[] { "Equipments", "Items", "ActiveEquipments" };


            foreach (var itemLocation in itemLocations)
            {
                string fullTypeName = $"NFCombat2.Models.Items.{itemLocation}.{typeName}, NFCombat2.Models";
                Type itemType = Type.GetType(fullTypeName);
                if (itemType != null)
                {
                    var item = Activator.CreateInstance(itemType);
                    return (Item)item;
                }
            }

            var item2 = Activator.CreateInstance(typeof(GrenadeLauncher));
            return (Item)item2;
        }

        private IAddable ConvertGenericItem(ItemType type)
        {
            return _genericItems[type];
        }

        private IAddable ConvertWeapon(ItemType type)
        {
            return _weapons[type];
        }

        Dictionary<ItemType, Item> ItemDictionary()
        {
            Language language = _playerService.CurrentPlayer.Language;
                
            return new Dictionary<ItemType, Item>()
                {
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                   {ItemType.CopperDiadem,new Item(){Name = GetItemName(ItemType.CopperDiadem, language)} },
                };

                
            
        }

        Dictionary<ItemType, Weapon> WeaponDictionary()
        {
            Language language = _playerService.CurrentPlayer.Language;
            return new Dictionary<ItemType, Weapon>()
            {
                {ItemType.PlasmaRapier, new Weapon(){
                    Name = GetItemName(ItemType.PlasmaRapier, language),
                    Accuracy = Accuracy.S,
                    MinRange = 0,
                    MaxRange = 0,
                    DamageDice = 0,
                    FlatDamage = 0,
                    AreaOfEffect = false,
                    Weight = 1
                //CONTINUE
                }},
            };
        }
    }
}
