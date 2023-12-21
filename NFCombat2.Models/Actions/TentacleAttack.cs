

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.Helpers.TentacleMessageTypeConverter;

namespace NFCombat2.Models.Actions
{
    public class TentacleAttack : ICombatAction
    {
        private EnemyType _enemyType;
        public TentacleAttack(EnemyType enemyType)
        {

            _enemyType = enemyType;

        }
        public MessageType MessageType => GetMessageType(_enemyType);

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            switch(_enemyType)
            {
                case EnemyType.TraumaTentacle:
                    resolutions.Add(new TraumaIncrease(fight.Player, 1));
                    break;
                case EnemyType.IonizationTentacle:
                    resolutions.Add(new IonizationIncrease(fight.Player, 1));
                    break;
                case EnemyType.PathogenTentacle:
                    resolutions.Add(new PathogenIncrease(fight.Player, 1));
                    break;
            }
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }
    }
}
