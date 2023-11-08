

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyMiss : ICombatResolution
    {
        private Enemy _enemy;
        public EnemyMiss(Enemy enemy)
        {
            _enemy = enemy;
        }
        public MessageType MessageType => MessageType.EnemyMissMessage;

        public string[] MessageArgs => new string[1] { _enemy.Name };

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
