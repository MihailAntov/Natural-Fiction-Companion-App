using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class ChangeDistance : ICombatResolution
    {
        public int Amount { get; set; }
        private Enemy _enemy;
   
        public ChangeDistance(int amount, Enemy enemy)
        {
            Amount = amount;
            _enemy = enemy;
            if(enemy.Distance < Math.Abs(Amount) && Amount < 0)
            {
                Amount = -enemy.Distance;
            }
            MessageArgs = new string[] { _enemy.Name, (_enemy.Distance + Amount).ToString() };

        }

        public MessageType MessageType => MessageType.ChangeDistanceMessage;
        public string[] MessageArgs { get; set; }
        public async Task Resolve(Fight fight)
        {
            _enemy.Distance += Amount;
        }
    }
}
