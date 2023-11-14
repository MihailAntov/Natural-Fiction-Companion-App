using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Extensions
{
    public static class ItemRepositorySeeder
    {
        public static async void SeedRepository(ItemRepository repository)
        {
            await repository.DeleteAll();
            var items = new List<ItemEntity>() 
            {
                new ItemEntity(){Name = "Grenade", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.Grenade},
                new ItemEntity(){Name = "Healing potion", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.HealingPotion},
                new ItemEntity(){Name = "Mobile health kit", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.MobileHealthKit},
                new ItemEntity(){Name = "Salt potion", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.SaltPotion},
                new ItemEntity(){Name = "Strength potion", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.StrengthPotion},
                new ItemEntity(){Name = "Wrench", Description = "TODO",Category = ItemCategory.Consumable, Type = ItemType.Wrench},
            };

            await repository.InsertRange(items);
        }
    }
}
