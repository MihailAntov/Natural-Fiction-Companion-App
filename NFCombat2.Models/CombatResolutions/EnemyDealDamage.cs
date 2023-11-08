

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyDealDamage : ICombatResolution
    {
        protected string _enemyName;
        public int Damage { get; set; }
        public EnemyDealDamage(DiceRollResult roll, Enemy enemy)
        {
            _enemyName = enemy.Name;
            Damage = roll.FlatAmount + roll.Dice.Select(d=>d.DiceValue).Sum();
        }
        public virtual MessageType MessageType => MessageType.EnemyDamageMessage;

        public virtual string[] MessageArgs => new string[2] { _enemyName, Damage.ToString() };

        public virtual async Task Resolve(Fight fight)
        {
            fight.Player.Health -= Damage;
            
        }
    }
}
