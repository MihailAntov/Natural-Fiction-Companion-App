﻿
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyCrit : EnemyDealDamage
    {

        public EnemyCrit(DiceRollResult roll, Enemy enemy) : base(roll, enemy) { }

        public override MessageType MessageType => MessageType.EnemyCritMessage;
        public override string[] MessageArgs => new string[2] { _enemyName, (Damage * 2).ToString() };
        public override Task Resolve(Fight fight)
        {
            fight.Player.Health -= Damage * 2;
            return Task.CompletedTask;
        }
    }
}