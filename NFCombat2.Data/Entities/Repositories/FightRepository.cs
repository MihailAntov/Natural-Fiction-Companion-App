using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Data.Extensions.FightRepositorySeeder;
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
        public FightRepository()
        {
            
        }

        public Fight? GetFight(int episodeNumber)
        {
            if (Fights.ContainsKey(episodeNumber))
            {
                var creatorFunc = Fights[episodeNumber];
                return creatorFunc();
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
    }
}
