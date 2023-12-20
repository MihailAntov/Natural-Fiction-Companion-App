
using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    internal class EnemyGetFurther : ICombatAction
    {
        private readonly Fight _fight;
        private Enemy _enemy;
        public EnemyGetFurther(Fight fight, Enemy enemy)
        {
            _fight = fight;
            _enemy = enemy;
        }

        public Enemy Enemy => _enemy;

        public MessageType MessageType => MessageType.EnemyMoveAwayMessage;

        public string[] MessageArgs => new string[1] { _enemy.Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyChangeDistance(_enemy.Speed,_enemy)
            };
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }
    }
}
