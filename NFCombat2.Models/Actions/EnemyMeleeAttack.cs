﻿

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Actions
{
    public class EnemyMeleeAttack : ICombatAction, IHaveOpposedRolls
    {
        private readonly Fight _fight;
        private readonly Enemy _enemy;
        public EnemyMeleeAttack(Fight fight, Enemy enemy)
        {
            _fight = fight;
            _enemy = enemy;
            AttackerResult = DiceCalculator.Calculate(1, null, enemy.Strength);
            DefenderResult = DiceCalculator.Calculate(1, null, _fight.Player.Strength);
            DiceMessageArgs[0] = _enemy.Name;
        }

        public DiceRollResult AttackerResult { get; set; }
        public DiceRollResult DefenderResult { get; set; }

        public string[] MessageArgs => new string[] { _enemy.Name };
        public MessageType MessageType => MessageType.EnemyAttackMessage;

        public string AttackerMessage { get; set; }

        public string DefenderMessage { get; set; }
        public DiceMessageType AttackerDiceMessageType => DiceMessageType.EnemyMeleeAttackRoll;
        public DiceMessageType DefenderDiceMessageType => DiceMessageType.PlayerMeleeAttackRoll;
        public string[] DiceMessageArgs { get; set; } = new string[1];
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            int attackerScore = AttackerResult.Dice.Sum(d => d.DiceValue) + AttackerResult.FlatAmount;
            int defenderScore = DefenderResult.Dice.Sum(d => d.DiceValue) + DefenderResult.FlatAmount;

            var result = new List<ICombatResolution>();

            if (attackerScore > defenderScore)
            {
                if(fight.Type == FightType.Virtual)
                {
                    var overload = new OverloadIncrease(fight.Player, 1);
                    result.Add(overload);
                    _fight.Effects.Enqueue(overload);
                }
                else
                {
                    var defeat = new TakeMeleeDamage(_fight.Player,_enemy, attackerScore - defenderScore);
                    result.Add(defeat);
                    _fight.Effects.Enqueue(defeat);
                }
                
            }
            else if (defenderScore > attackerScore)
            {
                if (fight.Type == FightType.Virtual)
                {
                    var noDamageVictory = new NoDamage();
                    result.Add(noDamageVictory);
                }
                else
                {
                    var victory = new DealMeleeDamage(_enemy, defenderScore - attackerScore);
                    result.Add(victory);
                    _fight.Effects.Enqueue(victory);
                }
            }
            else
            {
                result.Add(new Draw());

            }
            return result;
        }
    }
}
