﻿

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
        public void AffectFight()
        {
            throw new NotImplementedException();
        }
    }
}