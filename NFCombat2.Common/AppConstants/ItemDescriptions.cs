﻿

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ItemDescriptions
    {
        public static Dictionary<ItemType, string> EnglishItemDescriptions = new Dictionary<ItemType, string>
        {
            {ItemType.TacticalGlasses, " Increase your weapons' accuracy by one" },
            {ItemType.GasMask, "Provides protection from poisonous gases." },
            {ItemType.GrenadeLauncher, "The grenade launcher increases the damage of the weapon it´s attached to by one die" },
            {ItemType.Shuttle, "A small yet reliable shuttle suited for short interplanetary flights." },
            {ItemType.ArmoredVest, "Increases your maximum health by 5 points." },
            {ItemType.CamouflageSuit, "Lowers your opponents’ accuracy by one level (minimum E)." },
            {ItemType.Helmet, "When an opponent is to deal double damage to you, do not double the result." },
            {ItemType.NuclearWarhead, "\"Encapsulated destruction is best left encapsulated!\" - Bon Gess" },
            {ItemType.LaserSight, "Increases the accuracy of the weapon it's attached to by one level (maximum S). " },
            {ItemType.BarrelExtender, "Increasts the range of the weapon its attached to by 15 meters." },
            {ItemType.GasOperatedReloadingSystem, "Allows an extra shot per turn with the weapon it's attached to." },
            {ItemType.ChameleonSkin, "Reduces your opponents' accuracy by one level (minimum E) " },
            {ItemType.Bundle, "Can hold up to three items." },
            {ItemType.CombatSuit, "Increases your Strenght by 5 while you´re wearing it." },

            {ItemType.ArcWhip, "Melts the circuit boards of almost any machine. You can use it by adding 100 to the model number of the target and turning to the corresponding section. " },
            {ItemType.AutomatedMedKit, "The kit can be used once, including during combat, restoring up to 3 dice of health and reducing your Injuries, Pathogens, and Ionization degrees by one." },
            {ItemType.HandGrenade, "Used once during combat, the grenade deals two dice of damage to all enemies within a 10-meter radius." },
            {ItemType.PortableSurgicalLaser, "Holds a single charge that can restore 2 dice of health. The laser cannot be used during combat." },
            {ItemType.RocketPropelledFishingPole, "\"Used once during each combat, the jet hook increases or shortens the distance to your opponent by up to six meters.\r\nYou can also use it outside of combat to access hard-to-reach places or get out of dangerous situations, by adding 50 to the number of the section you're reading. \"" },
            {ItemType.PneumaticDrill, "The drill can crack doors as well as encrypted mechanisms. To use it, add 150 to the object's model number and turn to the resulting section." },
            {ItemType.PlatinumPhial, "Permanently increase your maximum degree of Overload by three. " },

            {ItemType.FuelCellBattery, "You can use the battery any time while you are on a spacecraft such as a shuttle or rocketplane. It will increase the energy capacity (EC) of its fuel cell by 30%." },
            {ItemType.ChargedGrapheneRod, "Used once during combat, it deals 7 dice + 7 damage to all opponents, regardless of distance." },
            {ItemType.RottingFruit, "Restores up to 4 points of health once, except during combat. " },
            {ItemType.SackOfAcorns, "Reduces your Pathogen degree by one, except during combat. " },
            {ItemType.Antivenom, "Reduces your Pathogens degree by one." },
            {ItemType.SackOfNeutralSoil, "Reduces your Ionization degree by one." },
            {ItemType.HerbalTincture, "Restores up to 2 dice of health." },
            {ItemType.BruteLeafExtract, "Increases your Strength by 2 for the duration of one battle." },
            {ItemType.SelfRepairFoam, "Reduces your Injury degree by one." },
            {ItemType.SodiumThiosulfateSerum, "Reduces your Pathogens degree by one." },
            {ItemType.PotassiumIodideTablets, "Reduces your Ionization degree by one." },
            {ItemType.Wrench, "The wrench can fit in the bag as well, and counts as a separate item. During combat, you may throw it once at an opponent within five meters to deal one die of damage." },
            {ItemType.AromaticSaltSolution, "Reduces your current Overload degree by two and increases its maximum degree by one." },
            {ItemType.PortableEnvironmentalSuit, "" },

            {ItemType.PlasmaRapier, "" },
            {ItemType.QuantumMagnumParadox, "" },
            {ItemType.Knife, "" },
            {ItemType.Flamethrower, "The flamethrower damages all enemies in range." },
            {ItemType.ConfiscatedRifle, "" },
            {ItemType.SemiautomaticPistol, "" },
            {ItemType.RailGun, "Whenever you deal double damage to an opponent with the gun, double the result once more." },
            {ItemType.TrainingRifle, "" },
            {ItemType.TrainingSniperRifle, "Has a minimum range of 10 meters." },
            {ItemType.JawHooks, "" },
            {ItemType.SniperPlasmaThrower, "Always deals 20 damage and has a minimal range of 10 meters." },
            {ItemType.CombatKnife, "" },
            {ItemType.AutomaticPistol, "" },
            {ItemType.AssaultRifle, "The rifle's rate of fire allows an extra shot per turn." },
            {ItemType.Shotgun, "" },
            {ItemType.HuntingShotgun, "" },
            {ItemType.PlasmaMinigun, "" },
            {ItemType.ShockBaton, "" },
            {ItemType.CurvedTail, "" },
            {ItemType.PlasmaThrower, "The plasma launcher always deals 10 damage." },
            {ItemType.ShortBarrelPlasmaThrower, "The plasma launcher always deals 10 damage." },
            {ItemType.DoubleBarrelShotgun, "The shotgun deals damage to all enemies in its range." },
            {ItemType.WrenchWeapon, "" },
            {ItemType.JaggedDagger, "" },
            {ItemType.Torch, "The portable flamethrower deals damage to all enemies in its range." },
            {ItemType.Chain, "" },
            {ItemType.SteelBar, "" },
            {ItemType.SteelPlate, "While carrying it, the plate will take all damage from firearms instead of you." },
            {ItemType.CalibratedRifle, "" },
            {ItemType.SmallCaliberPistol, "" },
            {ItemType.RocketLauncher, "" },
            {ItemType.MachineGun, "" },
            {ItemType.GravityModulator, "Carried in one hand, the shield slows the speed of all projectiles, reducing the damage taken from firearms by 3 points." },
            {ItemType.EMShield, "Carried in one hand, the shield creates a force field around its wielder, which reacts to physical contact, repelling the attacker. Whenever you lose health during melee combat, increase the distance to your opponent by one die." },
            {ItemType.SemiautomaticBeretta, "" },
            {ItemType.BoltActionCarbine, "Produces an additional shot when firing." },
            {ItemType.SniperRifle, "The sniper has a minimum range of 10 meters" },
            {ItemType.Magnum, "" },
            {ItemType.SawnOffShotgun, "Each shot deals damage to all enemies in its range." },

            {ItemType.CopperDiadem, "" },
            {ItemType.Rope, "" },
            {ItemType.AutomaticSaw, "" },
            {ItemType.FoodCapsules, "" },
            {ItemType.GrapheneRod, "" },
            {ItemType.AluminiumCanister, "" },
            {ItemType.CrystalNecklace, "" },
            {ItemType.FuelCanister, "" },
            {ItemType.MagnetDiscs, "" },
            {ItemType.IceSpark, "" },

            {ItemType.KabutoMainHand, "" },
            {ItemType.KabutoOffHand, "" },


        };

        public static Dictionary<ItemType, string> BulgarianItemDescriptions = new Dictionary<ItemType, string>
        {
            {ItemType.TacticalGlasses, "Увеличават точността на оръжията ти с една степен." },
            {ItemType.GasMask, "Осигурява защита от отровни газове." },
            {ItemType.GrenadeLauncher, "Гранатометът увеличава щетите на оръжието, към което е прикрепен, с един зар. " },
            {ItemType.Shuttle, "Малка но надеждна совалка, подходяща за кратки междупланетни полети." },
            {ItemType.ArmoredVest, "Увеличава максималната ти издръжливост с 5 точки." },
            {ItemType.CamouflageSuit, "Точността на противниците ти спада с една степен (минимум E)." },
            {ItemType.Helmet, "Когато противник трябва да ти нанесе двойни щети, не удвоява резултата." },
            {ItemType.NuclearWarhead, "\"Капсулираната разруха най-добре да остане капсулирана.\" - гл. инж. Бон Гес" },
            {ItemType.LaserSight, "Мерникът увеличава точността на оръжието, към което е прикрепен, с една степен (максимум S)" },
            {ItemType.BarrelExtender, "Увеличавайки обсега на оръжието, към което е прикрепен, с 15 метра. " },
            {ItemType.GasOperatedReloadingSystem, "Позволява допълнителен изстрел на ход с оръжието, към което е прикрепен." },
            {ItemType.ChameleonSkin, "Намалява точността на противниците ти с една степен (минимум E)." },
            {ItemType.Bundle, "Може да побере до три предмета." },
            {ItemType.CombatSuit, "Увеличава силата ти с 5, докато го носиш." },

            {ItemType.ArcWhip, "Способен е да претовари електрониката на почти всяка машина. " },
            {ItemType.AutomatedMedKit, "Използван еднократно, включително по време на битка, комплектът възстановява до 3 зара издръжливост и намалява степента на Травми, Патогени и Йонизация с по едно ниво." },
            {ItemType.HandGrenade, "Използвана еднократно по време на битка, гранатата нанася два зара щети на всички врагове в радиус от 10 метра." },
            {ItemType.PortableSurgicalLaser, "Използван еднократно, лазерът възстановява до 2 зара издръжливост. Лазерът не може да бъде ползван по време на битка." },
            {ItemType.RocketPropelledFishingPole, "\"Използвана веднъж по време на битка, реактивната въдица удължава или скъсява дистанцията до противника ти с до шест метра.\r\nМожеш да я използваш и извън битка, за да достигнеш труднодостъпни места или да се избавиш от опасни ситуации, като добавиш 50 към номера на епизода.\"" },
            {ItemType.PneumaticDrill, "Свределът разбива както врати, така и криптирани механизми. За да го използваш, добави 150 към номера на модела на обекта и премини на получения епизод. Ако той няма звездичка (*) в номера си, значи опитът не е успял." },
            {ItemType.PlatinumPhial, "Използвана еднократно, увеличава за постоянно максималната степен на Претоварване с три нива. " },

            {ItemType.FuelCellBattery, "Можеш да използваш батерията по всяко време, докато се намираш на космически кораб като совалка или ракетоплан. Тя ще увеличи енергийния капацитет (ЕК) на горивната му клетка с 30%." },
            {ItemType.ChargedGrapheneRod, "Използван еднократно по време на битка, той нанася щети в размер на 7 зара + 7 на всички противници, независимо от разстоянието. " },
            {ItemType.RottingFruit, "(еднократно възстановява до 4 точки издръжливост, освен по време на битка)" },
            {ItemType.SackOfAcorns, "(еднократно намалява степента на Патогени с едно ниво, освен по време на битка" },
            {ItemType.Antivenom, "Намалява степента на Патогени с едно ниво." },
            {ItemType.SackOfNeutralSoil, "Намалява степента на Йонизация с едно ниво." },
            {ItemType.HerbalTincture, "Възстановява до 2 зара издръжливост." },
            {ItemType.BruteLeafExtract, "Увеличава силата с 2 за времетраенето на една битка." },
            {ItemType.SelfRepairFoam, "Намалява степента на Травми с едно ниво." },
            {ItemType.SodiumThiosulfateSerum, "Намалява степента на Патогени с едно ниво." },
            {ItemType.PotassiumIodideTablets, "Намалява степента на Йонизация с едно ниво." },
            {ItemType.Wrench, "По време на битка можеш еднократно да ги хвърлиш по противник, намиращ се на не повече от пет метра, за да му нанесеш един зар щети." },
            {ItemType.AromaticSaltSolution, "Намалява степента на Претоварване с две нива и увеличава максималната му степен с едно ниво." },
            {ItemType.PortableEnvironmentalSuit, "" },

            {ItemType.PlasmaRapier, "" },
            {ItemType.QuantumMagnumParadox, "" },
            {ItemType.Knife, "" },
            {ItemType.Flamethrower, "Огнехвъргачката винаги поразява всички врагове в обсега си." },
            {ItemType.ConfiscatedRifle, "" },
            {ItemType.SemiautomaticPistol, "" },
            {ItemType.RailGun, "Всеки път, когато нанесеш двойни щети на противник с оръдието, удвои резултата още веднъж." },
            {ItemType.TrainingRifle, "" },
            {ItemType.TrainingSniperRifle, "Снайперът има минимален обсег от 10 метра." },
            {ItemType.JawHooks, "" },
            {ItemType.SniperPlasmaThrower, "Когато уцели, плазмометът нанася щети в размер на 20, и има минимален обсег от 10 метра." },
            {ItemType.CombatKnife, "" },
            {ItemType.AutomaticPistol, "" },
            {ItemType.AssaultRifle, "Скорострелността на винтовката позволява допълнителен изстрел на ход." },
            {ItemType.Shotgun, "" },
            {ItemType.HuntingShotgun, "" },
            {ItemType.PlasmaMinigun, "" },
            {ItemType.ShockBaton, "" },
            {ItemType.CurvedTail, "" },
            {ItemType.PlasmaThrower, "Когато уцели, плазмометът нанася щети в размер на 10." },
            {ItemType.ShortBarrelPlasmaThrower, "Когато уцели, плазмометът нанася щети в размер на 10." },
            {ItemType.DoubleBarrelShotgun, "Помпата нанася щети на всички противници в обсега ѝ." },
            {ItemType.WrenchWeapon, "" },
            {ItemType.JaggedDagger, "" },
            {ItemType.Torch, "Горелката винаги нанася щети на всички врагове в обсега ѝ." },
            {ItemType.Chain, "" },
            {ItemType.SteelBar, "" },
            {ItemType.SteelPlate, "Докато я носиш, плочката ще поема всички щети от огнестрелни оръжия вместо теб." },
            {ItemType.CalibratedRifle, "" },
            {ItemType.SmallCaliberPistol, "" },
            {ItemType.RocketLauncher, "" },
            {ItemType.MachineGun, "" },
            {ItemType.GravityModulator, "Носен в едната ръка, щитът забавя скоростта на всички проектили, намалявайки с 3 точки щетите, получени от огнестрелни оръжия." },
            {ItemType.EMShield, "Носен в едната ръка, щитът създава силово поле около притежателя си, което реагира на физически контакт, отблъсквайки нападателя. Всеки път, когато загубиш  издръжливост по време на близък бой, увеличавай дистанцията до противника с един зар." },
            {ItemType.SemiautomaticBeretta, "" },
            {ItemType.BoltActionCarbine, "Произвежда допълнителен изстрел на ход." },
            {ItemType.SniperRifle, "Снайперът има минимален обсег от 10 метра." },
            {ItemType.Magnum, "" },
            {ItemType.SawnOffShotgun, "Нанася щети на всички врагове в обсега ѝ." },

            {ItemType.CopperDiadem, "" },
            {ItemType.Rope, "" },
            {ItemType.AutomaticSaw, "" },
            {ItemType.FoodCapsules, "" },
            {ItemType.GrapheneRod, "" },
            {ItemType.AluminiumCanister, "" },
            {ItemType.CrystalNecklace, "" },
            {ItemType.FuelCanister, "" },
            {ItemType.MagnetDiscs, "" },
            {ItemType.IceSpark, "" },

            {ItemType.KabutoMainHand, "" },
            {ItemType.KabutoOffHand, "" },


        };
    }
}