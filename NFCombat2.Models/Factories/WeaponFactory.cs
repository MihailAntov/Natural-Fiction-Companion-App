

using Microsoft.Maui.Controls;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.Factories
{
    public static class WeaponFactory
    {
        private static Dictionary<ItemType, WeaponConfig> _weapons = new Dictionary<ItemType, WeaponConfig>()
        {
            {
                ItemType.PlasmaRapier,
                new WeaponConfig()
                {
                    Name = "Plasma Rapier",
                    Image = "plasmarapier",
                    Weight = 1,
                    ExtraStrength = 7,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.QuantumMagnumParadox,
                new WeaponConfig()
                {
                    Name = "Quantum Magnum \"Paradox\"",
                    Image = "revolver",
                    Weight = 1,
                    Accuracy = Accuracy.C,
                    DamageDice = 7,
                    FlatDamage = 7,
                    MaxRange = 10
                }
            },
            {
                ItemType.Knife,
                new WeaponConfig()
                {
                    Name = "Knife",
                    Image = "knife",
                    Weight = 1,
                    ExtraStrength = 1,
                    WeaponSpecial = WeaponSpecial.Melee,

                }
            },
            {
                ItemType.Flamethrower,
                new WeaponConfig()
                {
                    Name = "Flamethrower",
                    Image = "flame",
                    AreaOfEffect = true,
                    AlwaysHits = true,
                    Weight = 2,
                    MaxRange = 7,
                    DamageDice = 2
                }
            },
            {
                ItemType.ConfiscatedRifle,
                new WeaponConfig()
                {
                    Name = "ConfiscatedRifle",
                    Image = "rifle",
                    Accuracy = Accuracy.D,
                    MaxRange = 15,
                    DamageDice = 1,
                    FlatDamage = 2,
                    Weight = 1
                }
            },
            {
                ItemType.SemiautomaticPistol,
                new WeaponConfig()
                {
                    Name = "SemiautomaticPistol",
                    Image = "pistol",
                    Accuracy = Accuracy.B,
                    MaxRange = 10,
                    DamageDice = 1,
                    Weight = 1
                }
            },
            {
                ItemType.RailGun,
                new WeaponConfig()
                {
                    Name = "Rail Gun",
                    Image = "energyweapon",
                    Accuracy = Accuracy.B,
                    MaxRange = 25,
                    DamageDice = 3,
                    FlatDamage = 3,
                    Weight = 2,
                    CritMultiplier = 4,
                    
                }
            },
            {
                ItemType.TrainingRifle,
                new WeaponConfig()
                {
                    Name = "TrainingRifle",
                    Image = "rifle",
                    Accuracy = Accuracy.C,
                    MaxRange = 30,
                    DamageDice = 2,
                    Weight = 2
                }
            },
            {
                ItemType.TrainingSniperRifle,
                new WeaponConfig()
                {
                    Name = "TrainingSniperRifle",
                    Image = "sniper",
                    Accuracy = Accuracy.S,
                    MaxRange = 1000,
                    MinRange = 10,
                    DamageDice = 2,
                    Weight = 2
                }
            },
            {
                ItemType.JawHooks,
                new WeaponConfig()
                {
                    Name = "JawHooks",
                    Image = "hook",
                    ExtraStrength = 2,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.SniperPlasmaThrower,
                new WeaponConfig()
                {
                    Name = "SniperPlasmaThrower",
                    Image = "energyweapon",
                    Accuracy = Accuracy.S,
                    MaxRange = 1000,
                    MinRange = 10,
                    DamageDice = 0,
                    FlatDamage = 20,
                    Weight = 2,
                    
                }
            },
            {
                ItemType.CombatKnife,
                new WeaponConfig()
                {
                    Name = "CombatKnife",
                    Image = "knife",
                    ExtraStrength = 2,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.AutomaticPistol,
                new WeaponConfig()
                {
                    Name = "AutomaticPistol",
                    Image = "pistol",
                    Accuracy = Accuracy.A,
                    MaxRange = 10,
                    DamageDice = 1,
                    FlatDamage = 2,
                    Weight = 1
                }
            },
            {
                ItemType.AssaultRifle,
                new WeaponConfig()
                {
                    Name = "AssaultRifle",
                    Image = "assaultrifle",
                    Accuracy = Accuracy.A,
                    MaxRange = 30,
                    DamageDice = 2,
                    FlatDamage = 6,
                    Weight = 2,
                    ShotsPerTurn = 2,
                }
            },
            {
                ItemType.Shotgun,
                new WeaponConfig()
                {
                    Name = "Shotgun",
                    Image = "shotgun",
                    Accuracy = Accuracy.D,
                    MaxRange = 5,
                    DamageDice = 3,
                    Weight = 2
                }
            },
            {
                ItemType.PlasmaMinigun,
                new WeaponConfig()
                {
                    Name = "Plasma Minigun",
                    Image = "energyweapon",
                    Accuracy = Accuracy.B,
                    MaxRange = 30,
                    DamageDice = 2,
                    FlatDamage = 1,
                    Weight = 2
                }
            },
            {
                ItemType.ShockBaton,
                new WeaponConfig()
                {
                    Name = "Shock Baton",
                    Image = "baton",
                    ExtraStrength = 3,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.CurvedTail,
                new WeaponConfig()
                {
                    Name = "Curved Tail",
                    Image = "knife",
                    ExtraStrength = 4,
                    Weight = 2,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.PlasmaThrower,
                new WeaponConfig()
                {
                    Name = "Plasma Thrower",
                    Image = "energyweapon",
                    Accuracy = Accuracy.C,
                    MaxRange = 20,
                    FlatDamage = 10,
                    DamageDice = 0,
                    Weight = 2
                }
            },
            {
                ItemType.ShortBarrelPlasmaThrower,
                new WeaponConfig()
                {
                    Name = "ShortBarrelPlasmaThrower",
                    Image = "energyweapon",
                    Accuracy = Accuracy.C,
                    MaxRange = 10,
                    FlatDamage = 10,
                    DamageDice = 0,
                    Weight = 2,
                }
            },
            {
                ItemType.DoubleBarrelShotgun,
                new WeaponConfig()
                {
                    Name = "DoubleBarrelShotgun",
                    Image = "shotgun",
                    Accuracy = Accuracy.E,
                    MaxRange = 5,
                    DamageDice = 4,
                    Weight = 2,
                    AreaOfEffect = true
                }
            },
            {
                ItemType.WrenchWeapon,
                new WeaponConfig()
                {
                    Name = "Wrench",
                    Image = "wrench",
                    ExtraStrength = 1,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.JaggedDagger,
                new WeaponConfig()
                {
                    Name = "JaggedDagger",
                    Image = "dagger",
                    ExtraStrength = 3,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.Torch,
                new WeaponConfig()
                {
                    Name = "Torch",
                    Image = "blowtorch",
                    AlwaysHits = true,
                    MaxRange = 3,
                    DamageDice = 2,
                    AreaOfEffect = true,
                    Weight = 1
                }
            },
            {
                ItemType.Chain,
                new WeaponConfig()
                {
                    Name = "Chain",
                    Image = "chain",
                    ExtraStrength = 3,
                    Weight = 1,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.SteelBar,
                new WeaponConfig()
                {
                    Name = "SteelBar",
                    Image = "steelbar",
                    ExtraStrength = 4,
                    Weight = 2,
                    WeaponSpecial = WeaponSpecial.Melee,
                }
            },
            {
                ItemType.SteelPlate,
                new WeaponConfig()
                {
                    Name = "SteelPlate",
                    Image = "steelplate",
                    WeaponSpecial = WeaponSpecial.SteelPlate,
                }
            },
            {
                ItemType.CalibratedRifle,
                new WeaponConfig()
                {
                    Name = "CalibratedRifle",
                    Image = "rifle",
                    Accuracy = Accuracy.B,
                    MaxRange = 30,
                    DamageDice = 2,
                    Weight = 2
                }
            },
            {
                ItemType.SmallCaliberPistol,
                new WeaponConfig()
                {
                    Name = "Small Caliber Pistol",
                    Image = "pistol",
                    Accuracy = Accuracy.A,
                    MaxRange = 10,
                    DamageDice = 1,
                    Weight = 1
                }
            },
            {
                ItemType.RocketLauncher,
                new WeaponConfig()
                {
                    Name = "RocketLauncher",
                    Image = "rocketlauncher",
                    Accuracy = Accuracy.D,
                    MaxRange = 50,
                    DamageDice = 10,
                    Weight = 2
                }
            },
            {
                ItemType.MachineGun,
                new WeaponConfig()
                {
                    Name = "Machine Gun",
                    Image = "machinegun",
                    Accuracy = Accuracy.A,
                    MaxRange = 30,
                    DamageDice = 1,
                    FlatDamage = 3,
                    Weight = 1
                }
            },
            {
                ItemType.GravityModulator,
                new WeaponConfig()
                {
                    Name = "GravityModulator",
                    Image = "gravitymodulator",
                    WeaponSpecial = WeaponSpecial.GravityModulator,
                }
            },
            {
                ItemType.EMShield,
                new WeaponConfig()
                {
                    Name = "EMShield",
                    Image = "cybersecurity",
                    WeaponSpecial = WeaponSpecial.EMShield
                }
            },
            {
                ItemType.SemiautomaticBeretta,
                new WeaponConfig()
                {
                    Name = "SemiautomaticBeretta",
                    Image = "pistol",
                    Accuracy = Accuracy.A,
                    MaxRange = 15,
                    DamageDice = 1,
                    FlatDamage = 6,
                    Weight = 1
                }
            },
            {
                ItemType.BoltActionCarbine,
                new WeaponConfig()
                {
                    Name = "BoltActionCarbine",
                    Image = "rifle",
                    Accuracy = Accuracy.B,
                    MaxRange = 25,
                    DamageDice = 2,
                    Weight = 2,
                    ShotsPerTurn = 2
                }
            },
            {
                ItemType.SniperRifle,
                new WeaponConfig()
                {
                    Name = "SniperRifle",
                    Image = "sniper",
                    Accuracy = Accuracy.S,
                    MaxRange = 1000,
                    DamageDice = 3,
                    Weight = 2,
                    MinRange = 10
                }
            },
            {
                ItemType.Magnum,
                new WeaponConfig()
                {
                    Name = "Magnum",
                    Image = "revolver",
                    Accuracy = Accuracy.C,
                    MaxRange = 10,
                    DamageDice = 5,
                    FlatDamage = 5,
                    Weight = 1
                }
            },
            {
                ItemType.SawnOffShotgun,
                new WeaponConfig()
                {
                    Name = "SawnOffShotgun",
                    Image = "shotgun",
                    Accuracy = Accuracy.D,
                    MaxRange = 5,
                    DamageDice = 4,
                    Weight = 2,
                    AreaOfEffect = true,
                }
            }
        };

        public static Weapon GetWeapon(ItemType type, int itemId, params object[] args)
        {
            var config = _weapons[type];
            Hand hand = Hand.MainHand;
            if(args.Length > 0)
            {
                hand = (Hand)args[0];
            }
            switch (config.WeaponSpecial)
            {
                case WeaponSpecial.Melee:
                    MeleeWeapon meleeWeapon = new MeleeWeapon();
                    meleeWeapon.ExtraStrength = config.ExtraStrength;
                    meleeWeapon.Image = config.Image;
                    meleeWeapon.Id = itemId;
                    meleeWeapon.Hand = hand;
                    meleeWeapon.ItemType = type;
                    meleeWeapon.Weight = config.Weight;
                    return meleeWeapon;
                case WeaponSpecial.EMShield:
                    Weapon shield = new EMShield();
                    shield.Image = config.Image;
                    shield.Id = itemId;
                    shield.Hand = hand;
                    shield.ItemType = type;
                    shield.Weight = config.Weight;
                    return shield;
                case WeaponSpecial.GravityModulator:
                    Weapon modulator = new GravityModulator();
                    modulator.Image = config.Image;
                    modulator.Id = itemId;
                    modulator.Hand = hand;
                    modulator.ItemType = type;
                    modulator.Weight = config.Weight;
                    //TODO add shield and modulator stats to their configs
                    return modulator;
                case WeaponSpecial.None:
                default:
                    Weapon weapon = new Weapon()
                    {
                        Id = itemId,
                        ItemType = type,
                        Name = config.Name,
                        Accuracy = config.Accuracy,
                        DamageDice = config.DamageDice,
                        FlatDamage = config.FlatDamage,
                        Image = config.Image,
                        Hand = hand,
                        Weight = config.Weight,
                        MaxRange = config.MaxRange,
                        MinRange = config.MinRange,
                        ShotsPerTurn = config.ShotsPerTurn,
                        AreaOfEffect = config.AreaOfEffect,
                        AlwaysHits = config.AlwaysHits,
                        CritMultiplier = config.CritMultiplier,
                    };
                    return weapon;

            }

        }
    }
}
