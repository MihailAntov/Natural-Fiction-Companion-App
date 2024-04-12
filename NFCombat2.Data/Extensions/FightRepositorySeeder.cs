

using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Data.Extensions
{
    public class FightRepositorySeeder
    {
        public static Dictionary<int, Func<Fight>> Fights = new Dictionary<int, Func<Fight>>()
{
	// start																									
	{
        36,
        () => new TimedFight()
        {
            MaxTurns = 3,
            OnTurnsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.RegularBrute,
                    Health = 40,
                    Distance = 7,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            MaxRange = 15,
                            Accuracy = Accuracy.D
                        }
                    }
                }
            }
        }
    },
	// end																									
	// start																								
	{
        38,
        () => new TimedFight()
        {
            MaxTurns = 3,
            OnTurnsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.PaplacidGuard,
                    Health = 50,
                    Distance = 0
                }
            }
        }
    },
	// end																									
	// start template																								
	{
        39,
        () => new TimedFight()
        {
            MaxTurns = 3,
            OnTurnsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.RegularMeiCin,
                    Health = 35,
                    Distance = 6,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = 3,
                            MaxRange = 15,
                            Accuracy = Accuracy.A
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        57,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienAssassin,
                    Health = 16,
                    Distance = 6,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            MaxRange = 10,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        59,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienAttacker,
                    Health = 12,
                    Distance = 2,
                    BonusStrength = 1
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        90,
        () => new TimedFight()
        {
            MaxTurns = 3,
            OnTurnsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.NephropidCommando,
                    Health = 42,
                    Distance = 1
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        97,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienGuardA,
                    Health = 17,
                    Distance = 1,
                    BonusStrength = 1
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        120,
        () => new VirtualFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.HologramBrute,
                    Health = 18,
                    Distance = 4
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        121,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.InjuredMeiCin,
                    Health = 9,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        164,
        () => new HazardFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.SwampFoliage,
                    Health = 14,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        189,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DesertWormA,
                    Health = 33,
                    Distance = 4,
                    BonusStrength = 2
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        230,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.FelinterRookie,
                    Health = 14,
                    Distance = 15,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = 2,
                            MaxRange = 15,
                            Accuracy = Accuracy.D
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        260,
        () => new SkillCheckFight(CheckType.Rocks)
        {
            MinStrength = 0,
            CountWins = true,
            OnMinStrengthReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.PileOfRocks,
                    BonusStrength = 2,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        289,
        () => new SkillCheckFight(CheckType.River)
        {
            MinStrength = 0,
            LosingAtZeroFatal = true,
            OnMinStrengthReached = FightResult.Lost,
            MaxConsecutiveWins = 2,
            OnMaxConsecutiveRoundsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.UndergroundRiver,
                    BonusStrength = 2
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        315,
        () => new VariantFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.LtSide,
                    Health = 50,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            FlatDamage = 1,
                            MaxRange = 30,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        323,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DarkPaplacid,
                    Health = 18,
                    Distance = 7,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 0,
                            FlatDamage = 10,
                            MaxRange = 20,
                            Accuracy = Accuracy.C
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        373,
        () => new SkillCheckFight(CheckType.Panel)
        {
            MinStrength = 0,
            OnMinStrengthReached = FightResult.Lost,
            MaxConsecutiveWins = 1,
            OnMaxConsecutiveRoundsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.MetalPanel,
                    BonusStrength = 3
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        383,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.StripedBeast,
                    Health = 44,
                    BonusStrength = 4,
                    Speed = 7,
                    Distance = 48
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        391,
        () => new StationaryFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.VespisoidFugitive,
                    Health = 24,
                    Distance = 4
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        425,
        () => new TimedFight()
        {
            MaxTurns = 5,
            OnTurnsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.FirstPaplacidA,
                    Health = 33,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            FlatDamage = 1,
                            MaxRange = 10,
                            Accuracy = Accuracy.C
                        }
                    }
                },
                new Enemy()
                {
                    EnemyType = EnemyType.SecondPaplacidA,
                    Health = 28,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 4,
                            MaxRange = 5,
                            Accuracy = Accuracy.E
                        }
                    }
                },
                new Enemy()
                {
                    EnemyType = EnemyType.ThirdPaplacidA,
                    Health = 42,
                    BonusStrength = 3,
                    Distance = 2
                },
                new Enemy()
                {
                    EnemyType = EnemyType.FourthPaplacidA,
                    Health = 44,
                    BonusStrength = 4,
                    Distance = 2
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        430,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.FirstPaplacidB,
                    Health = 20,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 0,
                            FlatDamage = 10,
                            MaxRange = 10,
                            Accuracy = Accuracy.C
                        }
                    }
                },
                new Enemy()
                {
                    EnemyType = EnemyType.SecondPaplacidB,
                    Health = 18,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 4,
                            MaxRange = 5,
                            Accuracy = Accuracy.E
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        432,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.YoungDesertWorm,
                    Health = 18,
                    BonusStrength = 2,
                    Distance = 8
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        446,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienPilot,
                    Health = 11,
                    BonusStrength = 2,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        454,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.Sniper,
                    Health = 6,
                    Distance = 21,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            MaxRange = 1000,
                            MinRange = 10,
                            Accuracy = Accuracy.E
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        470,
        () => new TimedFight()
        {
            MaxTurns = 5,
            OnTurnsReached = FightResult.Won,
            MinEnemyHealth = 5,
            OnEnemyHealthReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienGuardB,
                    Health = 24,
                    BonusStrength = 3,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        477,
        () => new ChaseFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlientShooter,
                    Health = 16,
                    Distance = 64,
                    Speed = 8,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = 1,
                            MaxRange = 10,
                            Accuracy = Accuracy.B
                        }
                    }
                },
                new Enemy()
                {
                    EnemyType = EnemyType.AlienLeader,
                    Health = 11,
                    BonusStrength = 2,
                    Distance = 64,
                    Speed = 8
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        487,
        () => new SkillCheckFight(CheckType.Door)
        {
            MaxRounds = 5,
            MaxConsecutiveWins = 2,
            OnMaxRoundsReached = FightResult.Lost,
            OnMaxConsecutiveRoundsReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.MetalDoor,
                    BonusStrength = 2
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        500,
        () => new TimedFight()
        {
            MinEnemyHealth = 5,
            OnEnemyHealthReached = FightResult.Won,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.NephropidMechanic,
                    Health = 29,
                    BonusStrength = 1,
                    Distance = 35
                },
                new Enemy()
                {
                    EnemyType = EnemyType.FelinterMechanic,
                    Health = 28,
                    BonusStrength = 1,
                    Distance = 35
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        520,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienSentinel,
                    Health = 14,
                    BonusStrength = 2,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = 2,
                            MaxRange = 10,
                            Accuracy = Accuracy.A
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        522,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.GuardRobotAlpha,
                    Health = 50,
                    BonusStrength = 3,
                    Speed = 1,
                    Distance = 10
                },
                new Enemy()
                {
                    EnemyType = EnemyType.GuardRobotBeta,
                    Health = 40,
                    BonusStrength = 4,
                    Speed = 1,
                    Distance = 10
                },
                new Enemy()
                {
                    EnemyType = EnemyType.GuardRobotGamma,
                    Health = 60,
                    Speed = 1,
                    Distance = 10
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        527,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.UniformedAlien,
                    Health = 13,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 3,
                            MaxRange = 5,
                            Accuracy = Accuracy.D
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        546,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
					//todo: Add enum type for извънземен охранител																		
					EnemyType = EnemyType.AlienWarden,
                    Health = 17,
                    Distance = 5,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            MaxRange = 30,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        547,
        () => new Fight()
        {
            AllowsPrograms = false,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DefenseSystem,
                    Health = 20,
                    Distance = 15,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 3,
                            FlatDamage = 1,
                            MaxRange = 30,
                            Accuracy = Accuracy.A
                        },
                        new Weapon()
                        {
                            DamageDice = 3,
                            FlatDamage = 1,
                            MaxRange = 30,
                            Accuracy = Accuracy.A
                        },
                        new Weapon()
                        {
                            DamageDice = 3,
                            FlatDamage = 1,
                            MaxRange = 30,
                            Accuracy = Accuracy.A
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        569,
        () => new EscapeFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AlienGuardC,
                    Health = 18,
                    Distance = 3,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = 3,
                            MaxRange = 15,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        588,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DesertWormB,
                    Health = 33,
                    BonusStrength = 2,
                    Distance = 6
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        613,
        () => new TimedFight()
        {
            MinPlayerHealth = 10,
            OnPlayerHealthReached = FightResult.Lost,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.AgentZorgy,
                    Health = 20,
                    BonusStrength = 1,
                    Distance = 0
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        618,
        () => new ChaseFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.MotivatedAlienPursuer,
                    Health = 12,
                    Distance = 25,
                    Speed = 10,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = -1,
                            MaxRange = 10,
                            Accuracy = Accuracy.D
                        },
                        new Weapon()
                        {
                            DamageDice = 1,
                            FlatDamage = -1,
                            MaxRange = 10,
                            Accuracy = Accuracy.D
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        620,
        () => new TimedFight()
        {
            MaxTurns = 3,
            OnTurnsReached = FightResult.Lost,
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DefenseGun,
                    Health = 6,
                    Distance = 2,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 1,
                            MaxRange = 5,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        628,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.FelinterWarrior,
                    Health = 20,
                    BonusStrength = 1,
                    Distance = 15,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            MaxRange = 30,
                            Accuracy = Accuracy.E
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        635,
        () => new VariantFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.CommanderKabuto,
                    Health = 120,
                    Distance = 15,
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            DamageDice = 2,
                            FlatDamage = 2,
                            MaxRange = 25,
                            Accuracy = Accuracy.C
                        },
                        new Weapon()
                        {
                            DamageDice = 2,
                            MaxRange = 30,
                            Accuracy = Accuracy.B
                        }
                    }
                }
            }
        }
    },
	// end template																									
	// start template																								
	{
        679,
        () => new Fight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.DesertWormC,
                    Health = 22,
                    BonusStrength = 2,
                    Distance = 11
                }
            }
        }
    },
	// end template																									
	{
        219,
        () => new TentacleFight()
        {
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    EnemyType = EnemyType.TraumaTentacle,
                    Health = 10,
                    Distance = 5,
                },
                new Enemy()
                {
                    EnemyType = EnemyType.IonizationTentacle,
                    Health = 10,
                    Distance = 5,
                },
                new Enemy()
                {
                    EnemyType = EnemyType.PathogenTentacle,
                    Health = 10,
                    Distance = 5,
                }
            }
        }
    },
};
    }
}
