

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyDealDamage : ICombatResolution
    {
        private string _enemyName;
        private int _damage;
        public EnemyDealDamage(DiceRollResult roll, Enemy enemy)
        {
            _enemyName = enemy.Name;
            _damage = roll.FlatAmount + roll.Dice.Select(d=>d.DiceValue).Sum();
        }
        public MessageType MessageType => MessageType.EnemyDamageMessage;

        public string[] MessageArgs => new string[2] { _enemyName, _damage.ToString() };

        public void Resolve(Fight fight)
        {
            fight.Player.Health -= _damage;
        }
    }
}
