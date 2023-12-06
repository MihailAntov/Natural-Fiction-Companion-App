

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
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
        }

        public DiceRollResult AttackerResult { get; set; }
        public DiceRollResult DefenderResult { get; set; }

        public string[] MessageArgs => new string[] { _enemy.Name };
        public MessageType MessageType => MessageType.EnemyAttackMessage;

        public string AttackerMessage => $"{_enemy.Name}'s melee attack roll:";

        public string DefenderMessage => "Your melee attack roll:";

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            int attackerScore = AttackerResult.Dice.Sum(d => d.DiceValue) + AttackerResult.FlatAmount;
            int defenderScore = DefenderResult.Dice.Sum(d => d.DiceValue) + DefenderResult.FlatAmount;

            var result = new List<ICombatResolution>();

            if (attackerScore > defenderScore)
            {
                var defeat = new TakeMeleeDamage(_fight.Player,_enemy, attackerScore - defenderScore);
                result.Add(defeat);
                _fight.Effects.Enqueue(defeat);
                
            }
            else if (defenderScore > attackerScore)
            {
                var victory = new DealMeleeDamage(_enemy, defenderScore - attackerScore);
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
