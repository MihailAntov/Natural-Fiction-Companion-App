using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class ChangeDistance : IAffectCombat
    {
        private int _amount;
        private Enemy _enemy;
        public ChangeDistance(int amount, Enemy enemy)
        {
            _amount = amount;
            _enemy = enemy;
        }

        public MessageType MessageType => MessageType.ChangeDistanceMessage;

        public void AffectFight(Fight fight)
        {
            _enemy.Distance -= _amount;
        }
    }
}
