using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class PlayerStrengthCheckAttack : PlayerMeleeAttack
    {
        private readonly SkillCheckFight _fight;
        public PlayerStrengthCheckAttack(Fight fight) : base(fight, fight.Enemies.FirstOrDefault())
        {
            _fight = (SkillCheckFight)fight;
            Target = fight.Enemies.FirstOrDefault();
            AttackerResult = DiceCalculator.Calculate(1, null, ((SkillCheckFight)_fight).PlayerStrength);
            DefenderResult = DiceCalculator.Calculate(1, null, Target.Strength);
        }
        public override MessageType MessageType => SkillCheckMessageTypeConverter.GetMessageType(_fight.CheckType);



        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {

            int attackerScore = AttackerResult.Dice.Sum(d => d.DiceValue) + AttackerResult.FlatAmount;
            int defenderScore = DefenderResult.Dice.Sum(d => d.DiceValue) + DefenderResult.FlatAmount;

            var result = new List<ICombatResolution>();

            if (attackerScore > defenderScore)
            {
                var victory = new SkillCheckSuccess();
                result.Add(victory);
                if(fight is SkillCheckFight skillCheck)
                {
                    skillCheck.WonRounds++;
                    if (skillCheck.WonLastRound)
                    {
                        skillCheck.ConsecutiveWins++;
                    }
                    else
                    {
                        skillCheck.ConsecutiveWins = 1;

                    }
                    skillCheck.WonLastRound = true;
                }
            }
            else if (defenderScore > attackerScore)
            {
                var defeat = new TemporaryStrengthLoss(defenderScore - attackerScore);
                result.Add(defeat);
                _fight.Effects.Enqueue(defeat);
                if(fight is SkillCheckFight skillCheck)
                {
                    skillCheck.WonLastRound = false;
                    skillCheck.ConsecutiveWins = 0;
                }
            }
            else
            {
                result.Add(new Draw());
                if (fight is SkillCheckFight skillCheck)
                {
                    skillCheck.WonLastRound = false;
                    skillCheck.ConsecutiveWins = 0;
                }

            }
            return result;
        }
    }
}
