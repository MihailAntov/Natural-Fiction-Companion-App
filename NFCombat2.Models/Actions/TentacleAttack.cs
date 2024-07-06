

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.Helpers.TentacleMessageTypeConverter;

namespace NFCombat2.Models.Actions
{
    public class TentacleAttack : ICombatAction, IHaveRolls
    {
        public EnemyType EnemyType { get; set; }
        private string _enemyName;
        public TentacleAttack(EnemyType enemyType, string enemyName)
        {

            EnemyType = enemyType;
            _enemyName = enemyName;
            RollsResult = DiceCalculator.Calculate(1);
            DiceMessageArgs[0] = _enemyName;

        }
        public MessageType MessageType => GetMessageType(EnemyType);

        public string[] MessageArgs => Array.Empty<string>();

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.TentacleRoll;
        public string[] DiceMessageArgs { get; set; } = new string[1];
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            bool hit = RollsResult.Dice.FirstOrDefault().DiceValue % 2 == 0;
            switch(EnemyType)
            {
                case EnemyType.TraumaTentacle:
                    if (hit)
                    {
                        resolutions.Add(new TraumaIncrease(fight.Player, 1));
                        break;
                    }
                    resolutions.Add(new TraumaTentacleMiss());
                    break;
                case EnemyType.IonizationTentacle:
                    if (hit)
                    {
                        resolutions.Add(new IonizationIncrease(fight.Player, 1));
                        break;
                    }
                    resolutions.Add(new IonizationTentacleMiss());
                    break;
                case EnemyType.PathogenTentacle:
                    if (hit)
                    {
                        resolutions.Add(new PathogenIncrease(fight.Player, 1));
                        break;
                    }
                    resolutions.Add(new PathogenTentacleMiss());
                    break;
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
