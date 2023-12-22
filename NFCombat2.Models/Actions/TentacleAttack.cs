

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.Helpers.TentacleMessageTypeConverter;

namespace NFCombat2.Models.Actions
{
    public class TentacleAttack : ICombatAction, IHaveAttackRoll
    {
        private EnemyType _enemyType;
        public TentacleAttack(EnemyType enemyType)
        {

            _enemyType = enemyType;

        }
        public MessageType MessageType => GetMessageType(_enemyType);

        public string[] MessageArgs => Array.Empty<string>();

        public Dice AttackRollResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Accuracy Accuracy => throw new NotImplementedException();

        public string AttackDiceMessage => throw new NotImplementedException();

        public bool AlwaysHits => throw new NotImplementedException();

        public IList<ICombatResolution> AddCritToCombatResolutions(Fight fight)
        {
            throw new NotImplementedException();
        }

        public IList<ICombatResolution> AddMissToCombatResolutions(Fight fight)
        {
            throw new NotImplementedException();
        }

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
