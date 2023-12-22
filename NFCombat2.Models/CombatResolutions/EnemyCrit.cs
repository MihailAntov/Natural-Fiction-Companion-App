
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.CombatResolutions
{
    public class EnemyCrit : EnemyDealDamage
    {

        public EnemyCrit(DiceRollResult roll, Enemy enemy) : base(roll, enemy) 
        {
            
        }
        public int CritMultiplier { get; set; } = 2;
        public override MessageType MessageType => MessageType.EnemyCritMessage;
        public override string[] MessageArgs => new string[2] { _enemyName, Damage.ToString() };
        public override Task Resolve(Fight fight)
        {
            Damage = base.Damage * CritMultiplier;
            if (fight.Player.Equipment.Any(e=> e is Helmet))
            {
                fight.Player.Health -= Damage;
                return Task.CompletedTask;
            }
            fight.Player.Health -= Damage;
            return Task.CompletedTask;
        }
    }
}
