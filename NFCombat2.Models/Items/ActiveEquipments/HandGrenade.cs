﻿using NFCombat2.Common.Helpers;

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class HandGrenade : ActiveEquipment, ICombatActiveItem, IHaveRolls
    {
        
        public HandGrenade()
        {
            RollsResult = DiceCalculator.Calculate(2);
            IsConsumable = true;
            Quantity = 1;
            IsInvention = true;
        }
        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.HandGrenadeRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {

            //Quantity--;
            //if(Quantity <= 0)
            //{
            //    fight.Player.Equipment.Remove(this);
            //}

            
            var targets = fight.Enemies.Where(e => e.Distance <= 10).ToList();
            ICombatResolution damage = new DealDamage(RollsResult, targets);
            fight.Effects.Enqueue(damage);
            RollsResult = DiceCalculator.Calculate(2);
            return new List<ICombatResolution>() { damage };
        }

    }
}
