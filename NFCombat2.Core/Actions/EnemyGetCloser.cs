

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class EnemyGetCloser : IMoveAction
    {
        private readonly Fight _fight;
        private Enemy _enemy;
        public EnemyGetCloser(Fight fight, Enemy enemy)
        {
            _fight = fight;
            _enemy = enemy;
        }

        public string Label => throw new NotImplementedException();

        public Enemy Enemy => _enemy;
        public string Description => throw new NotImplementedException();

        public MessageType MessageType => MessageType.EnemyMoveMessage;

        public string[] MessageArgs => new string[] { Enemy.Name, Enemy.Distance.ToString() };

        public void AffectFight(Fight fight)
        {
            foreach(var enemy in fight.Enemies)
            {
                enemy.Distance -= enemy.Speed;
                if (enemy.Distance < 0)
                {
                    enemy.Distance = 0;
                }
            }
        }
    }
}
