using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Programs;
using NFCombat2.Data.Entities;

namespace NFCombat2.Data.Extensions
{
    public static class ItemRepositorySeeder
    {
        public static async void SeedRepository(PlayerRepository repository)
        {
            await repository.DeleteAllItems();

            var items = new List<ItemEntity>() 
            {
                //equipments
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.TacticalGlasses},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.GasMask},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.GrenadeLauncher,IsInvention = true, IsCraftOnly = true, Formula = "hhhhhhhkz", Episode = 17 },
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Shuttle,IsInvention = true, Formula = "bffffffffffffiiiiiiiiiiiikqwwwwwwwwww", Episode = 12},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ArmoredVest},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.CamouflageSuit},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Helmet},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.NuclearWarhead,IsInvention = true,IsCraftOnly = true, Formula = "deeegghhhhnrzzzzzzzzzz", Episode = 3},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.LaserSight,IsInvention = true,IsCraftOnly = true, Formula = "eeeeeeeelx", Episode = 18},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.BarrelExtender,IsInvention = true,IsCraftOnly = true, Formula = "hhhhhj", Episode = 56},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.GasOperatedReloadingSystem,IsInvention = true, Formula = "ggggghhhm",Episode = 86},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ChameleonSkin},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Bundle},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.CombatSuit},

                //active equipments
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ArcWhip,IsInvention = true,IsCraftOnly = true,Formula="eeefflpuu",Episode=25},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.AutomatedMedKit,IsInvention = true, Formula = "efglptx",Episode = 10},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.HandGrenade,IsInvention = true, Formula = "hhhjoz", Episode = 4},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.PortableSurgicalLaser,IsInvention = true,Formula="eelox",Episode=7},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.RocketPropelledFishingPole,IsCraftOnly = true,IsInvention = true, Formula = "fffjos", Episode=28},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.PneumaticDrill,IsInvention = true,IsCraftOnly = true, Formula="ffffkot",Episode=35},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.PlatinumPhial},

                //active items
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.FuelCellBattery},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.ChargedGrapheneRod},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.RottingFruit},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.SackOfAcorns},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.Antivenom},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.SackOfNeutralSoil},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.HerbalTincture},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.BruteLeafExtract},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.SelfRepairFoam},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.SodiumThiosulfateSerum},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.PotassiumIodideTablets},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.Wrench},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.AromaticSaltSolution},
                new ItemEntity(){Category = ItemCategory.Item, Type = ItemType.PortableEnvironmentalSuit},

                //weapons
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.PlasmaRapier,IsInvention = true,IsCraftOnly = true, Formula = "ceghmptttxxx", Episode = 8},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.QuantumMagnumParadox,IsCraftOnly = true, Formula = "dfhhhhhhhhnovvvvv", Episode = 22},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Knife},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Flamethrower,IsInvention = true,IsCraftOnly = true, Formula = "bghhhmovz",Episode = 29},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.ConfiscatedRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SemiautomaticPistol},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.RailGun,IsInvention = true,IsCraftOnly = true, Formula = "ceeegggghhhhhlpuuuvvv",Episode = 78},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.TrainingRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.TrainingSniperRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.JawHooks},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SniperPlasmaThrower},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.CombatKnife},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.AutomaticPistol},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.AssaultRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Shotgun},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.PlasmaMinigun},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.ShockBaton},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.CurvedTail},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.PlasmaThrower},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.ShortBarrelPlasmaThrower},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.DoubleBarrelShotgun},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.WrenchWeapon},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.JaggedDagger},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Torch},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Chain},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SteelBar},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SteelPlate},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.CalibratedRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SmallCaliberPistol},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.RocketLauncher},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.MachineGun},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.GravityModulator,IsInvention = true, Formula = "agggmqyyy", Episode = 34},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.EMShield,IsInvention = true, Formula = "aeeeeelpyy", Episode = 41},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SemiautomaticBeretta},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.BoltActionCarbine},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SniperRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Magnum},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SawnOffShotgun},
            
            
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.CopperDiadem},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.Rope},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.AutomaticSaw},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.FoodCapsules},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.GrapheneRod},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.AluminiumCanister},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.CrystalNecklace},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.FuelCanister},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.MagnetDiscs},
                new ItemEntity(){ Category = ItemCategory.GenericItem, Type = ItemType.IceSpark},
            };

            await repository.InsertRange(items);
            var programs = new List<ProgramEntity>()
            {
                new ProgramEntity(){Type = ProgramType.ReceiveNOptimizeNMove},
                new ProgramEntity(){Type = ProgramType.ReceiveNOptimizeNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveNOptimizeNAnalyze},
                new ProgramEntity(){Type = ProgramType.ReceiveNOptimizeFix},
                new ProgramEntity(){Type = ProgramType.ReceiveNExtendNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveNDirectNMove},
                new ProgramEntity(){Type = ProgramType.ReceiveNDirectNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveDirectNMove},
                new ProgramEntity(){Type = ProgramType.ReceiveDirectNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveDirectNAnalyze},
                new ProgramEntity(){Type = ProgramType.ReceiveDirectFix},
                new ProgramEntity(){Type = ProgramType.ReceiveExtendNMove},
                new ProgramEntity(){Type = ProgramType.ReceiveExtendNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveOptimizeNMove},
                new ProgramEntity(){Type = ProgramType.ReceiveOptimizeNFix},
                new ProgramEntity(){Type = ProgramType.ReceiveOptimizeNAnalyze},
                new ProgramEntity(){Type = ProgramType.ReceiveOptimizeFix},
                new ProgramEntity(){Type = ProgramType.SendDirectNUnlock}
            };
            await repository.InsertRange(programs);
        }
    }
}
