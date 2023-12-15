using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class PlayerSwampAttack : PlayerStrengthCheckAttack
    {
        private Fight _fight;
        public PlayerSwampAttack(Fight fight) : base(fight)
        {
            _fight = fight;
        }

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            int attackerScore = AttackerResult.Dice.Sum(d => d.DiceValue) + AttackerResult.FlatAmount;
            int defenderScore = DefenderResult.Dice.Sum(d => d.DiceValue) + DefenderResult.FlatAmount;

            var result = new List<ICombatResolution>();

            if (attackerScore > defenderScore)
            {
                var victory = new DealMeleeDamage(Target, attackerScore - defenderScore);
                result.Add(victory);
                _fight.Effects.Enqueue(victory);
            }
            else
            {
                result.Add(new Draw());

            }
            return result;
        }
    }
}
