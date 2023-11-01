

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Actions
{
    public class EnemyRangedAttack : IStandardAction
    {
        private readonly Fight fight;
        private readonly Weapon _weapon;
        public EnemyRangedAttack(Fight fight, Weapon weapon)
        {
            this.fight = fight;
            _weapon = weapon;
        }

        public string Label => throw new NotImplementedException();
        public string Description =>throw new NotImplementedException();
        public string[] MessageArgs => new string[] { _weapon.Label};
        public MessageType MessageType => MessageType.EnemyShootMessage;

        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
