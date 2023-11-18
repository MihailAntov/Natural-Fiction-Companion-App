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
                //equipments
                new ItemEntity(){Name = "Tactical Glasses", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.TacticalGlasses},
                new ItemEntity(){Name = "Gas Mask", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.GasMask},
                new ItemEntity(){Name = "Grenade Launcher", IsCraftOnly = true , Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.GrenadeLauncher},
                new ItemEntity(){Name = "Shuttle", IsCraftOnly= true, Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.Shuttle},
                new ItemEntity(){Name = "Armored Vest", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.ArmoredVest},
                new ItemEntity(){Name = "Camouflage Suit", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.CamouflageSuit},
                new ItemEntity(){Name = "Helmet",Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.Helmet},
                new ItemEntity(){Name = "Nuclear Warhead", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.NuclearWarhead},
                new ItemEntity(){Name = "Laser Sight", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.LaserSight},
                new ItemEntity(){Name = "Barrel Extender", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.BarrelExtender},
                new ItemEntity(){Name = "Gas Operated Reloading System", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.GasOperatedReloadingSystem},
                new ItemEntity(){Name = "Chameleon Skin", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.ChameleonSkin},
                new ItemEntity(){Name = "Bundle", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.Bundle},

                //active equipments
                new ItemEntity(){Name = "Arc Whip", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.ArcWhip},
                new ItemEntity(){Name = "Automated Med Kit", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.AutomatedMedKit},
                new ItemEntity(){Name = "Hand Grenade", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.HandGrenade},
                new ItemEntity(){Name = "Portable Surgical Laser", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.PortableSurgicalLaser},
                new ItemEntity(){Name = "Rocket Propelled Fishing Pole", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.RocketPropelledFishingPole},
                new ItemEntity(){Name = "Pneumatic Drill", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.PneumaticDrill},
                new ItemEntity(){Name = "Platinum Phial", Description = "TODO",Category = ItemCategory.Equipment, Type = ItemType.PlatinumPhial},

                //active items
                new ItemEntity(){Name = "Fuel Cell Battery", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.FuelCellBattery},
                new ItemEntity(){Name = "Charged Graphene Rod", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.ChargedGrapheneRod},
                new ItemEntity(){Name = "Rotting Fruit", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.RottingFruit},
                new ItemEntity(){Name = "Sack of Acorns", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SackOfAcorns},
                new ItemEntity(){Name = "Antivenom", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.Antivenom},
                new ItemEntity(){Name = "SackOfNeutralSoil", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SackOfNeutralSoil},
                new ItemEntity(){Name = "Herbal Tincture", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.HerbalTincture},
                new ItemEntity(){Name = "Brute Leaf Extract", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.BruteLeafExtract},
                new ItemEntity(){Name = "Self Repair Foam", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SelfRepairFoam},
                new ItemEntity(){Name = "Sodium Thiosulfate Serum", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.SodiumThiosulfateSerum},
                new ItemEntity(){Name = "Potassium Iodide Tablets", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.PotassiumIodideTablets},
                new ItemEntity(){Name = "Wrench", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.Wrench},
                new ItemEntity(){Name = "Aromatic Salt Solution", Description = "TODO",Category = ItemCategory.Item, Type = ItemType.AromaticSaltSolution},

                //weapons
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
                new ItemEntity(){Name = "TODO", Description="TODO", Category = ItemCategory.Weapon, Type = ItemType.TODO},
            };

            await repository.InsertRange(items);
        }
    }
}
