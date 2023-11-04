

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
namespace NFCombat2.Models.Actions
{
    public class EnemyMeleeAttack : ICombatAction
    {
        private readonly Fight fight;
        private readonly Enemy _enemy;
        public EnemyMeleeAttack(Fight fight, Enemy enemy)
        {
            this.fight = fight;
            _enemy = enemy;
        }


        public string[] MessageArgs => new string[] { _enemy.Name };
        public MessageType MessageType => MessageType.EnemyAttackMessage;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
