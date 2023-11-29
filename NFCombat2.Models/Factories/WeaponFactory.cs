

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
                    Image = "knife",
                    Weight = 1,
                    ExtraStrength = 7
                }
            },
            {
                ItemType.QuantumMagnumParadox,
                new WeaponConfig()
                {
                    Name = "Quantum Magnum \"Paradox\"",
                    Image = "pistol",
                    Weight = 1,
                    Accuracy = Accuracy.C,
                    DamageDice = 7,
                    FlatDamage = 7,
                }
            },
            {
                ItemType.Knife,
                new WeaponConfig()
                {
                    Name = "Knife",
                    Image = "knife",
                    Weight = 1,
                }
            },
            {
                ItemType.Flamethrower,
                new WeaponConfig()
                {
                    Name = "Flamethrower",
                    Image = "flame",
                    WeaponSpecial = WeaponSpecial.AreaOfEffect,
                    AlwaysHits = true,
                    Weight = 2
                }
            },
            {
                ItemType.ConfiscatedRifle,
                new WeaponConfig()
                {
                    Name = "ConfiscatedRifle"
                }
            },
            {
                ItemType.SemiautomaticPistol,
                new WeaponConfig()
                {
                    Name = "SemiautomaticPistol"
                }
            },
            {
                ItemType.RailGun,
                new WeaponConfig()
                {
                    Name = "RailGun"
                }
            },
            {
                ItemType.TrainingRifle,
                new WeaponConfig()
                {
                    Name = "TrainingRifle"
                }
            },
            {
                ItemType.TrainingSniperRifle,
                new WeaponConfig()
                {
                    Name = "TrainingSniperRifle"
                }
            },
            {
                ItemType.JawHooks,
                new WeaponConfig()
                {
                    Name = "JawHooks"
                }
            },
            {
                ItemType.SniperPlasmaThrower,
                new WeaponConfig()
                {
                    Name = "SniperPlasmaThrower"
                }
            },
            {
                ItemType.CombatKnife,
                new WeaponConfig()
                {
                    Name = "CombatKnife"
                }
            },
            {
                ItemType.AutomaticPistol,
                new WeaponConfig()
                {
                    Name = "AutomaticPistol"
                }
            },
            {
                ItemType.AssaultRifle,
                new WeaponConfig()
                {
                    Name = "AssaultRifle"
                }
            },
            {
                ItemType.Shotgun,
                new WeaponConfig()
                {
                    Name = "Shotgun"
                }
            },
            {
                ItemType.PlasmaMinigun,
                new WeaponConfig()
                {
                    Name = "PlasmaMinigun"
                }
            },
            {
                ItemType.ShockBaton,
                new WeaponConfig()
                {
                    Name = "ShockBaton"
                }
            },
            {
                ItemType.CurvedTail,
                new WeaponConfig()
                {
                    Name = "CurvedTail"
                }
            },
            {
                ItemType.PlasmaThrower,
                new WeaponConfig()
                {
                    Name = "PlasmaThrower"
                }
            },
            {
                ItemType.ShortBarrelPlasmaThrower,
                new WeaponConfig()
                {
                    Name = "ShortBarrelPlasmaThrower"
                }
            },
            {
                ItemType.DoubleBarrelShotgun,
                new WeaponConfig()
                {
                    Name = "DoubleBarrelShotgun"
                }
            },
            {
                ItemType.WrenchWeapon,
                new WeaponConfig()
                {
                    Name = "WrenchWeapon"
                }
            },
            {
                ItemType.JaggedDagger,
                new WeaponConfig()
                {
                    Name = "JaggedDagger"
                }
            },
            {
                ItemType.Torch,
                new WeaponConfig()
                {
                    Name = "Torch"
                }
            },
            {
                ItemType.Chain,
                new WeaponConfig()
                {
                    Name = "Chain"
                }
            },
            {
                ItemType.SteelBar,
                new WeaponConfig()
                {
                    Name = "SteelBar"
                }
            },
            {
                ItemType.SteelPlate,
                new WeaponConfig()
                {
                    Name = "SteelPlate"
                }
            },
            {
                ItemType.CalibratedRifle,
                new WeaponConfig()
                {
                    Name = "CalibratedRifle"
                }
            },
            {
                ItemType.SmallCaliberPistol,
                new WeaponConfig()
                {
                    Name = "SmallCaliberPistol"
                }
            },
            {
                ItemType.RocketLauncher,
                new WeaponConfig()
                {
                    Name = "RocketLauncher"
                }
            },
            {
                ItemType.Minigun,
                new WeaponConfig()
                {
                    Name = "Minigun"
                }
            },
            {
                ItemType.GravityModulator,
                new WeaponConfig()
                {
                    Name = "GravityModulator"
                }
            },
            {
                ItemType.EMShield,
                new WeaponConfig()
                {
                    Name = "EMShield"
                }
            },
            {
                ItemType.SemiautomaticBeretta,
                new WeaponConfig()
                {
                    Name = "SemiautomaticBeretta"
                }
            },
            {
                ItemType.BoltActionCarbine,
                new WeaponConfig()
                {
                    Name = "BoltActionCarbine"
                }
            },
            {
                ItemType.SniperRifle,
                new WeaponConfig()
                {
                    Name = "SniperRifle"
                }
            },
            {
                ItemType.Magnum,
                new WeaponConfig()
                {
                    Name = "Magnum"
                }
            },
            {
                ItemType.SawnOffShotgun,
                new WeaponConfig()
                {
                    Name = "SawnOffShotgun"
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
                    meleeWeapon.Id = itemId;
                    meleeWeapon.Hand = hand;
                    return meleeWeapon;
                case WeaponSpecial.Shield:
                    Weapon shield = new EMShield();
                    shield.Id = itemId;
                    shield.Hand = hand;
                    return shield;
                case WeaponSpecial.None:
                default:
                    Weapon weapon = new Weapon()
                    {
                        Id = itemId,
                        Name = config.Name,
                        Accuracy = config.Accuracy,
                        FlatDamage = config.FlatDamage,
                        Image = config.Image,
                        Hand = hand,
                        Weight = config.Weight,
                    };
                    return weapon;

            }

        }
    }
}
