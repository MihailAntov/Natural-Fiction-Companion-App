﻿

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Actions
{
    public class PlayerMeleeAttack : IStandardAction, ITarget, IHaveOpposedRolls
    {
        private readonly Fight _fight;
        public PlayerMeleeAttack(Fight fight, Enemy target)
        {
            _fight = fight;
            Target = target;
            AttackerResult = DiceCalculator.Calculate(1, null, _fight.Player.Strength);
            DefenderResult = DiceCalculator.Calculate(1, null, target.Strength);
            DiceMessageArgs[0] = Target.Name;
        }
        public string[] MessageArgs => new string[] { Target?.Name };
        public string Name => "Melee Attack";
        public string Description { get; set; }

        public ICollection<Enemy> Targets { get; set; }
        public Enemy Target { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 0;

        public virtual MessageType MessageType => MessageType.AttackMessage;

        public DiceRollResult AttackerResult { get; set; }

        public string AttackerMessage { get; set; }
        public DiceMessageType AttackerDiceMessageType => DiceMessageType.PlayerMeleeAttackRoll;

        public DiceRollResult DefenderResult { get; set; }

        public string DefenderMessage { get; set; }
        public DiceMessageType DefenderDiceMessageType => DiceMessageType.EnemyMeleeAttackRoll;
        public string[] DiceMessageArgs { get; set; } = new string[1];
        public virtual IList<ICombatResolution> AddToCombatEffects(Fight fight)
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
            else if (defenderScore > attackerScore)
            {
                var defeat = new TakeMeleeDamage(_fight.Player,Target, defenderScore - attackerScore);
                result.Add(defeat);
                _fight.Effects.Enqueue(defeat);
            }
            else
            {
                result.Add(new Draw());
                
            }
            return result;
        }
    }
}
