using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class DiceMessages
    {
        public static Dictionary<DiceMessageType, string> EnglishDiceMessages = new Dictionary<DiceMessageType, string>()
        {
            {DiceMessageType.ProgramDamageRoll, "Your program's damage" },
            {DiceMessageType.DelayedProgramDamageRoll, "Your program's follow-up damage" },
            {DiceMessageType.ProgramHealingRoll, "Your program's healing" },
            {DiceMessageType.DelayedProgramHealingRoll, "Your program's follow-up healing" },
            {DiceMessageType.PlayerMeleeAttackRoll, "Your melee attack" },
            {DiceMessageType.PlayerRangedAttackRoll, "Your attack" },
            {DiceMessageType.PlayerRangedDamageRoll, "Your damage" },
            {DiceMessageType.EnemyMeleeAttackRoll, "{0}'s melee attack" },
            {DiceMessageType.EnemyRangedAttackRoll, "{0}'s attack" },
            {DiceMessageType.EnemyRangedDamageRoll, "{0}'s damage" },
            {DiceMessageType.WrenchRoll, "Your wrench's damage" },
            {DiceMessageType.SwampRoll, "The swamp's roll" },
            {DiceMessageType.TentacleRoll, "{0}'s roll" },
            {DiceMessageType.MedKitRoll, "Your automated medkit's healing" },
            {DiceMessageType.HandGrenadeRoll, "Your hand grenade's damage" },
            {DiceMessageType.SurgicalKitRoll, "Your surgical kit's healing" },
            {DiceMessageType.GrapheneRodRoll, "Your graphene rod's damage" },
            {DiceMessageType.HerbalTinctureRoll, "Your herbal tincture's healing" },
            {DiceMessageType.PushAwayRoll, "Your shield's pushback" },
        };
    }
}

