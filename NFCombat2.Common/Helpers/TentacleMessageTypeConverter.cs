

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.Helpers
{
    public static class TentacleMessageTypeConverter
    {
        public static MessageType GetMessageType(EnemyType type)
        {
            switch (type)
            {
                default:
                case EnemyType.TraumaTentacle:
                    return MessageType.TraumaTentacleAttack;
                case EnemyType.IonizationTentacle:
                    return MessageType.IonizationTentacleAttack;
                case EnemyType.PathogenTentacle:
                    return MessageType.PathogenTentacleAttack;

            }
        }
    }
}
