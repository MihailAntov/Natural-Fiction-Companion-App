using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Programs;

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
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.GrenadeLauncher, IsCraftOnly = true, Formula = "GGG", Episode = 123 },
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Shuttle, IsCraftOnly= true, Formula = "SSS", Episode = 321},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ArmoredVest},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.CamouflageSuit},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Helmet},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.NuclearWarhead},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.LaserSight},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.BarrelExtender},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.GasOperatedReloadingSystem},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ChameleonSkin},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.Bundle},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.CombatSuit},

                //active equipments
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.ArcWhip},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.AutomatedMedKit},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.HandGrenade},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.PortableSurgicalLaser},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.RocketPropelledFishingPole},
                new ItemEntity(){Category = ItemCategory.Equipment, Type = ItemType.PneumaticDrill},
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
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.PlasmaRapier},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.QuantumMagnumParadox},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Knife},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.Flamethrower},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.ConfiscatedRifle},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.SemiautomaticPistol},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.RailGun},
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
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.GravityModulator},
                new ItemEntity(){Category = ItemCategory.Weapon, Type = ItemType.EMShield},
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
