

using Intents;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyChangeDistance : ICombatResolution
    {
        
        private Enemy _enemy;
        private int _amount;
        public EnemyChangeDistance(int amount, Enemy enemy)
        {
            _enemy = enemy;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.EnemyChangeDistanceMessage;

        public string[] MessageArgs => new string[2] { _enemy.Name , string.Empty};

        public void Resolve(Fight fight)
        {
            _enemy.Distance += _amount;
            MessageArgs[1] = _enemy.Distance.ToString();
        }
    }
}
