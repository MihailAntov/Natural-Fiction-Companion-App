using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class EnemyMovePass : ICombatAction
    {
        private Enemy _enemy;
        public EnemyMovePass(Enemy enemy)
        {
            _enemy = enemy;
        }

        public Enemy Enemy => _enemy;

        public MessageType MessageType => MessageType.EnemyMovePassMessage;

        public string[] MessageArgs => new string[1] { Enemy.Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            return new List<ICombatResolution>();
        }
    }
}

