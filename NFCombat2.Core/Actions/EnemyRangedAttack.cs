

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Models.DiceRoller.DiceCalculator;
using NFCombat2.Models.Items;
using NFCombat2.Models.DiceRoller;

namespace NFCombat2.Models.Actions
{
    public class EnemyRangedAttack : ICombatAction
    {
        private readonly Fight fight;
        private readonly Enemy _enemy;
        public EnemyRangedAttack(Fight fight, Enemy enemy)
        {
            this.fight = fight;
            _enemy = enemy;
        }


        public string[] MessageArgs => new string[] { _enemy.Name};
        public MessageType MessageType => MessageType.EnemyShootMessage;

        public IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var damage = DiceCalculator.Calculate(_enemy.DamageDice, _enemy.FlatDamage);
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyDealDamage(damage,_enemy)
            };
            return resolutions;
        }
    }
}
