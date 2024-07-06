

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;
using System.Security.Cryptography.X509Certificates;

namespace NFCombat2.Models.Actions
{
    public class SwampAttack : ICombatAction, IHaveRolls
    {
        public SwampAttack()
        {
            RollsResult = DiceCalculator.Calculate(1);
        }
        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.SwampRoll;

        public MessageType MessageType => MessageType.SwampAttack;

        public string[] MessageArgs => Array.Empty<string>();
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            if(RollsResult.Dice.Any(d=>d.DiceValue <= 2))
            {
                resolutions.Add(new PathogenIncrease(fight.Player, 1));
            }
            else
            {
                resolutions.Add(new HoldBreath());
            }

            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(1);
            return resolutions;
        }
    }
}
