﻿

using Microsoft.VisualBasic;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.Fights
{
    public class Variant
    {
        public VariantDescription Type { get; set; } = VariantDescription.None;
        public string Text { get; set; }
        public int AnthenasBlocked { get; set; } = 0;
        public bool DoubleDamage { get; set; } = false;
        public Weapon DiscardedWeapon { get; set; }
        public int Distance { get; set; } = 15;
        public void Apply(Fight fight)
        {
            if(Type == VariantDescription.AnthenasBlocked)
            {
                fight.Enemies.FirstOrDefault().Health -= 20 * AnthenasBlocked;
                if(DoubleDamage)
                {
                    fight.HasFirstStrike= true;
                    fight.RemainingCrits++;
                }
            }

            if(Type == VariantDescription.IceSpark)
            {
                fight.Result = FightResult.Won;
            }

            if(Type == VariantDescription.MagnetDiscs)
            {
                
                fight.Enemies.FirstOrDefault().Weapons.Remove(DiscardedWeapon);
            }

            if(Type == VariantDescription.RookieFelinter)
            {
                var enemy = fight.Enemies.FirstOrDefault();
                fight.Enemies.FirstOrDefault().Distance = Distance;
            }
        }
    }
}
