

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class SpawnTentacle : ICombatAction
    {
        private EnemyType _enemyType;
        private string _name;
        public SpawnTentacle(EnemyType enemyType, string name)
        {
            _enemyType = enemyType;
            _name = name;
        }
        public MessageType MessageType => MessageType.SpawnTentacle;
        
        public string[] MessageArgs => new string[1] { _name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var tentacle = new Enemy()
            {
                Name = _name,
                EnemyType = _enemyType,
                Distance = 5,
                Health = 10
            };
            fight.Enemies.Add(tentacle);
            return new List<ICombatResolution>();
            
        }
    }
}
