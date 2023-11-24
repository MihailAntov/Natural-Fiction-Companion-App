

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Actions
{
    public class EnemyRangedAttack : ICombatAction, IHaveAttackRoll, IHaveRolls
    {
        private readonly Fight fight;
        private readonly Enemy _enemy;
        private Accuracy _accuracy;
        public EnemyRangedAttack(Fight fight, Enemy enemy)
        {
            this.fight = fight;
            _enemy = enemy;
            AttackRollResult = DiceCalculator.Calculate(1, AttackDiceMessage).Dice.FirstOrDefault();
            RollsResult = DiceCalculator.Calculate(enemy.DamageDice, DiceMessage, enemy.FlatDamage);
            _accuracy = _enemy.Accuracy;
        }

        public bool IsAccuracyReduced { get; set; } = false;
        public string[] MessageArgs => new string[] { _enemy.Name};
        public MessageType MessageType => MessageType.EnemyShootMessage;

        public DiceRollResult RollsResult { get; set; }
        public Dice AttackRollResult { get; set; }
        public Accuracy BaseAccuracy { get; set; }
        public Accuracy Accuracy => IsAccuracyReduced ? (BaseAccuracy < Accuracy.E ? BaseAccuracy + 1: BaseAccuracy) : BaseAccuracy;
          
        

        public string AttackDiceMessage => $"{MessageArgs[0]}'s attack:";
        public string DiceMessage => $"{MessageArgs[0]}'s damage:";

        public IList<ICombatResolution> AddCritToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyCrit(RollsResult ,_enemy)
            };
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }

        public IList<ICombatResolution> AddMissToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyMiss(_enemy)
            };
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyDealDamage(RollsResult ,_enemy)
            };
            
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }

            return resolutions;
        }
    }
}
