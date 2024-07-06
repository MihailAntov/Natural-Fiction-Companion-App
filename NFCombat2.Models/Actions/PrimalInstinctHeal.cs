using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class PrimalInstinctHeal : ICombatAction, IHaveRolls
    {
        public PrimalInstinctHeal()
        {
            RollsResult = DiceCalculator.Calculate(2);
        }
        public MessageType MessageType => MessageType.PrimalInstinctHealmessage;

        public string[] MessageArgs => Array.Empty<string>();

        public DiceRollResult RollsResult { get; set; }

        public DiceMessageType DiceMessageType => DiceMessageType.PrimalInstictHealRoll;

        public string DiceMessage { get; set; }
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            var heal = new Heal(RollsResult);
            resolutions.Add(heal);
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(2);
            return resolutions;
        }
    }
}
