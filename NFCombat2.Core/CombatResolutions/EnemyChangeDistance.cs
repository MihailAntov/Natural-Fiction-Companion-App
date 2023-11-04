

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyChangeDistance : ICombatResolution
    {
        
        private Enemy _enemy;
        private int _amount;
        private string[] _messageArgs = new string[2];
        public EnemyChangeDistance(int amount, Enemy enemy)
        {
            _enemy = enemy;
            _amount = amount;
            _messageArgs[0] = enemy.Name;
            _messageArgs[1] = Math.Max(enemy.Distance + _amount, 0).ToString();
        }
        public MessageType MessageType => MessageType.EnemyChangeDistanceMessage;

        public string[] MessageArgs => _messageArgs;

        public void Resolve(Fight fight)
        {
            _enemy.Distance += _amount;
            MessageArgs[1] = _enemy.Distance.ToString();
        }
    }
}
