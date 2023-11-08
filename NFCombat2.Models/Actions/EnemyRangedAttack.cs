

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
        public EnemyRangedAttack(Fight fight, Enemy enemy)
        {
            this.fight = fight;
            _enemy = enemy;
            AttackRollResult = DiceCalculator.Calculate(1).Dice.FirstOrDefault();
            RollsResult = DiceCalculator.Calculate(enemy.DamageDice, enemy.FlatDamage);
        }


        public string[] MessageArgs => new string[] { _enemy.Name};
        public MessageType MessageType => MessageType.EnemyShootMessage;

        public DiceRollResult RollsResult { get; set; }
        public Dice AttackRollResult { get; set; }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyDealDamage(RollsResult ,_enemy)
            };
            return resolutions;
        }
    }
}
