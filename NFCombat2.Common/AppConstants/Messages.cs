﻿

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class Messages
    {
        public static Dictionary<MessageType, string> EnglishMessages = new Dictionary<MessageType, string>()
        {
            {MessageType.BonusActionMessage, "{You can take another action this turn." },
            {MessageType.CritMessage, "You deal double damage!" },
            {MessageType.DamageMessage, "{0} takes {1} damage." },
            {MessageType.TakeDamageMessage, "You take {0} damage." },
            {MessageType.FreezeMessage, "{0} cannot move for another {1} turns." },
            {MessageType.HealMessage, "You restore {0} health." },
            {MessageType.ChangeDistanceMessage, "The closest enemy is now at {0} meters." },
            {MessageType.ShootMessage, "You shoot {0} with your {1}" },
            {MessageType.AttackMessage, "You attack {0} in close combat." },
            {MessageType.UseProgramMessage, "You use {0}. Your overload gauge is now at {1}." },
            {MessageType.ProgramHealMessage, "Your program heals you." },
            {MessageType.ProgramBonusActionmessage, "Your program increases your reflexes." },
            {MessageType.ProgramDamageMessage, "Your program damages your enemy." },
            {MessageType.ProgramCritMessage, "Your program focuses your aim." },
            {MessageType.ProgramFreezeMessage, "Your program disrupts the movement of your enemy." },
            {MessageType.UseItemWithQuantityMessage, "You use one of your {0}. You have {0} left." },
            {MessageType.UseItemMessage, "You use your {0}." },
            {MessageType.UseTechniqueMessage, "You use {}." },
            {MessageType.MoveCloserMessage, "You move in closer." },
            {MessageType.MovePassMessage, "You stay where you are." },
            {MessageType.ActionPassMessage, "You wait." },
            {MessageType.EnemyMoveMessage, "{0} moves in closer, and is now {1} meters away from you." },
            {MessageType.EnemyShootMessage, "{0} shoots with {1}" },
            {MessageType.EnemyAttackMessage, "{0} attacks you in close combat." },
            {MessageType.EnemyDefeatedMessage, "{0} is defeated!" }
        };

        public static Dictionary<MessageType, string> BulgarianMessages = new Dictionary<MessageType, string>()
        {
            {MessageType.BonusActionMessage, "TODO" },
            {MessageType.CritMessage, "TODO" },
            {MessageType.DamageMessage, "TODO" },
            {MessageType.TakeDamageMessage, "TODO" },
            {MessageType.FreezeMessage, "TODO" },
            {MessageType.HealMessage, "TODO" },
            {MessageType.ChangeDistanceMessage,"TODO" },
            {MessageType.ShootMessage, "TODO" },
            {MessageType.AttackMessage, "TODO" },
            {MessageType.UseProgramMessage, "TODO" },
            {MessageType.ProgramDamageMessage, "TODO" },
            {MessageType.ProgramBonusActionmessage, "TODO" },
            {MessageType.ProgramCritMessage, "TODO" },
            {MessageType.ProgramHealMessage, "TODO" },
            {MessageType.ProgramFreezeMessage, "TODO" },
            {MessageType.UseItemMessage, "TODO" },
            {MessageType.UseItemWithQuantityMessage, "TODO" },
            {MessageType.UseTechniqueMessage, "TODO" },
            {MessageType.MoveCloserMessage, "TODO" },
            {MessageType.MovePassMessage, "TODO" },
            {MessageType.ActionPassMessage, "TODO" },
            {MessageType.EnemyMoveMessage, "TODO" },
            {MessageType.EnemyShootMessage, "TODO" },
            {MessageType.EnemyAttackMessage, "TODO" },
            {MessageType.EnemyDefeatedMessage, "TODO" },
        };
    }
}


////combat effect messages
//BonusActionMessage,
//CritMessage,
//DamageMessage,
//TakeDamageMessage,
//FreezeMessage,
//HealMessage,
////action messages
//UseProgramMessage,
//UseItemMessage,
//UseTechniqueMessage,
//MoveMessage,
//MovePassMessage,
//ActionPassMessage,
////enemy messages
//EnemyMoveMessage,
//EnemyShootMessage,
//EnemyAttackMessage,
//EnemyDefeatedMessage