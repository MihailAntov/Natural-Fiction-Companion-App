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
                new ItemEntity(){Name = "Grenade", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.HandGrenade},
                new ItemEntity(){Name = "Bundle", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.Bundle},
                new ItemEntity(){Name = "Grenade Launcher", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.GrenadeLauncher},
                new ItemEntity(){Name = "Helmet", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.Helmet},
                new ItemEntity(){Name = "Tactical Glasses", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.TacticalGlasses},
                new ItemEntity(){Name = "Wrench", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.Wrench},
                new ItemEntity(){Name = "Self Repair Foam", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SelfRepairFoam},
                new ItemEntity(){Name = "Rotting Fruit", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.RottingFruit},
                new ItemEntity(){Name = "Sack of Acorns", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SackOfAcorns},
            };

            await repository.InsertRange(items);
        }
    }
}
