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
        
        public ItemService(ItemRepository repository)
        {
            _repository = repository;
        }

        

        
    }
}
