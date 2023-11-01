

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Actions
{
    public class EnemyRangedAttack : IStandardAction
    {
        private readonly Fight fight;
        public EnemyRangedAttack(Fight fight)
        {
            this.fight = fight;
        }

        public string Label => throw new NotImplementedException();
        public string Description =>throw new NotImplementedException();

        public MessageType MessageType => MessageType.EnemyShootMessage;

        public void AffectFight(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
