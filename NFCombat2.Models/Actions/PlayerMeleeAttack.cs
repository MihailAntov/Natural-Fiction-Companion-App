

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;

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
        }
        public string[] MessageArgs => new string[] { Target?.Name };
        public string Label => "Melee Attack";
        public string Description { get; set; }

        public ICollection<Enemy> Targets { get; set; }
        public Enemy Target { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 0;

        public MessageType MessageType => MessageType.AttackMessage;

        public DiceRollResult AttackerResult { get; set; }

        public string AttackerMessage => "Your melee attack roll:";

        public DiceRollResult DefenderResult { get; set; }

        public string DefenderMessage => $"{Target.Name}'s melee attack roll:";

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            int attackerScore = AttackerResult.Dice.Sum(d => d.DiceValue) + AttackerResult.FlatAmount;
            int defenderScore = DefenderResult.Dice.Sum(d => d.DiceValue) + DefenderResult.FlatAmount;

            var result = new List<ICombatResolution>();

            if (attackerScore > defenderScore)
            {
                result.Add(new DealMeleeDamage(Target, attackerScore - defenderScore));
            }
            else if (defenderScore > attackerScore)
            {
                result.Add(new TakeMeleeDamage(_fight.Player, defenderScore - attackerScore));
            }
            else
            {
                result.Add(new Draw());
                
            }
            return result;
        }
    }
}
