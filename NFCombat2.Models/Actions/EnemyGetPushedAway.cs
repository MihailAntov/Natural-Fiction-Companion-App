using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    internal class EnemyGetPushedAway : ICombatAction, IHaveRolls
    {
        private readonly Fight _fight;
        private Enemy _enemy;
        public EnemyGetPushedAway(Fight fight, Enemy enemy)
        {
            _fight = fight;
            _enemy = enemy;
            RollsResult = DiceCalculator.Calculate(1);
        }

        public Enemy Enemy => _enemy;

        public MessageType MessageType => MessageType.EnemyPushedBackMessage;

        public string[] MessageArgs => new string[1] {Enemy.Name};

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.PushAwayRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyChangeDistance(RollsResult.Dice.FirstOrDefault().DiceValue,_enemy)
            };

            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }
    }
}
