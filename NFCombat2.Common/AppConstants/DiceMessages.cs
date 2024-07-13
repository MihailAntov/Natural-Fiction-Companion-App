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
            {DiceMessageType.PrimalInstictHealRoll, "Your primal instinct healing roll" },
            {DiceMessageType.ComboDamageRoll, "Your combo damage roll" },
        };

        public static Dictionary<DiceMessageType, string> BulgarianDiceMessages = new Dictionary<DiceMessageType, string>()

        {

            {DiceMessageType.ProgramDamageRoll, "Щетите на програмата ти" },
            {DiceMessageType.DelayedProgramDamageRoll, "Последващите щети на програмата ти "},
            {DiceMessageType.ProgramHealingRoll, "Лечението от програмата ти" },
            {DiceMessageType.DelayedProgramHealingRoll, "Последващото лечение от програмата ти" },
            {DiceMessageType.PlayerMeleeAttackRoll, "Атаката ти отблизо" },
            {DiceMessageType.PlayerRangedAttackRoll, "Атаката ти" },
            {DiceMessageType.PlayerRangedDamageRoll, "Щетите на атаката ти" },
            {DiceMessageType.EnemyMeleeAttackRoll, "Атаката на {0} отблизо " },
            {DiceMessageType.EnemyRangedAttackRoll, "Атаката на {0}" },
            {DiceMessageType.EnemyRangedDamageRoll, "Щетите на атаката на {0}" },
            {DiceMessageType.WrenchRoll, "Щетите на гаечния ти ключ" },
            {DiceMessageType.SwampRoll, "Хвърлянето на блатото" },
            {DiceMessageType.TentacleRoll, "Хвърлянето на {0}" },
            {DiceMessageType.MedKitRoll, "Лечението от автоматизирания ти медицински комплект "},
            {DiceMessageType.HandGrenadeRoll, "Щетите на гранатата ти" },
            {DiceMessageType.SurgicalKitRoll, "Лечението от портативния ти хирургически лазер" },
            {DiceMessageType.GrapheneRodRoll, "Щетите на заредения ти графенов прът" },
            {DiceMessageType.HerbalTinctureRoll, "Лечението от билковата ти тинктура" },
            {DiceMessageType.PushAwayRoll, "Отблъскването на елекотромагнитния ти щит" },
            {DiceMessageType.PrimalInstictHealRoll, "Лечението от първичния ти инстинкт" },
            {DiceMessageType.ComboDamageRoll, "Щетите от серията ти" },

        };
    }
}

