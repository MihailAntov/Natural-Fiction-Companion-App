﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class EnemyGetCloser : ICombatAction
    {
        private readonly Fight _fight;
        private Enemy _enemy;
        public EnemyGetCloser(Fight fight, Enemy enemy)
        {
            _fight = fight;
            _enemy = enemy;
        }

        public Enemy Enemy => _enemy;

        public MessageType MessageType => MessageType.None;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>() 
            {
                new EnemyChangeDistance(-_enemy.Speed,_enemy) 
            };
            return resolutions;
        }
    }
}
