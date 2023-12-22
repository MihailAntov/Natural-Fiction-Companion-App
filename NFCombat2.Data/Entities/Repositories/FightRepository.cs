using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Weapons;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Repositories
{
    public class FightRepository
    {
        public bool Seeded { get; set; } = false;
        

        //protected SQLiteAsyncConnection connection = null!;
        //public string StatusMessage { get; set; } = string.Empty;

        public FightRepository()
        {
            
        }

        public Fight? GetFight(int episodeNumber)
        {
            if (Fights.ContainsKey(episodeNumber))
            {
                return Fights[episodeNumber];
            }
            return null;
            
        }
        public List<IOption> GetVariants(int episodeNumber)
        {
            var variants = new List<IOption>();
            if(episodeNumber == 8)
            {
                var variant0 = new Variant()
                {
                    Text = "No anthennas blocked",
                    AnthenasBlocked = 0,
                    Type = VariantDescription.AnthenasBlocked
                };

                var variant1 = new Variant()
                {
                    Text = "One anthenna blocked",
                    AnthenasBlocked = 1,
                    Type = VariantDescription.AnthenasBlocked
                };

                var variant2 = new Variant()
                {
                    Text = "Two anthennas blocked",
                    AnthenasBlocked = 2,
                    Type = VariantDescription.AnthenasBlocked
                };
                variants.Add(new Option(variant0.Text, variant0));
                variants.Add(new Option(variant1.Text, variant1));
                variants.Add(new Option(variant2.Text, variant2));
            }
            else if (episodeNumber == 9)
            {
                variants.Add(new Option("None", new Variant() { Text = "None"}));
                variants.Add(new Option("Ice Spark", new Variant() { Text = "Ice Spark",Type = VariantDescription.IceSpark}));
                variants.Add(new Option("Magnet Discs", new Variant() { Text = "Magnet Discs",Type = VariantDescription.MagnetDiscs}));
            }
            return variants;
            
        }

        private static Dictionary<int, Fight> Fights = new Dictionary<int, Fight>()
        {
            // start
            {
                36, new TimedFight()
                {
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
            {
                219, new TentacleFight()
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
