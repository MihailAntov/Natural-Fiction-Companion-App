

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class Messages
    {
        public static Dictionary<MessageType, string> EnglishMessages = new Dictionary<MessageType, string>()
        {
            //effects
            {MessageType.BonusActionMessage, "You can take another action this turn." },
            {MessageType.CritMessage, "Your next {0} shots deal double damage!" },
            {MessageType.DamageMessage, "{0} takes {1} damage." },
            {MessageType.DamageAoeMessage, "{0} enemies each take {1} damage." },
            {MessageType.TakeDamageMessage, "You take {0} damage." },
            {MessageType.FreezeAoeMessage, "{0} enemies cannot move for {1} turns." },
            {MessageType.FreezeMessage, "{0} cannot move for {1} turns." },
            {MessageType.IsFrozenMessage, "{0} cannot move. ({1} turns remaining)" },
            {MessageType.HealMessage, "You restore {0} health." },
            {MessageType.ChangeDistanceMessage, "{0} is now at {1} meters." },
            //actions
            {MessageType.ShootMessage, "You shoot {0} with your {1}" },
            {MessageType.AttackMessage, "You attack {0} in close combat." },
            {MessageType.UseProgramMessage, "You use {0}. Your overload gauge is now at {1}." },
            {MessageType.UseItemWithQuantityMessage, "You use one of your {0}. You have {0} left." },
            {MessageType.UseItemMessage, "You use your {0}." },
            {MessageType.UseTechniqueMessage, "You use {}." },
            {MessageType.MoveCloserMessage, "You move in closer." },
            {MessageType.MovePassMessage, "You stay where you are." },
            {MessageType.ActionPassMessage, "You wait." },
            //program action messages
            {MessageType.ProgramHealMessage, "Your program heals you." },
            {MessageType.ProgramBonusActionmessage, "Your program increases your reflexes." },
            {MessageType.ProgramDamageMessage, "Your program damages your enemy." },
            {MessageType.ProgramCritMessage, "Your program focuses your aim." },
            {MessageType.ProgramFreezeMessage, "Your program disrupts the movement of your enemy." },
            //enemy messages
            {MessageType.EnemyMoveMessage, "{0} moves in closer." }, // not used currently
            {MessageType.EnemyShootMessage, "{0} shoots with {1}" },
            {MessageType.EnemyAttackMessage, "{0} attacks you in close combat." },
            {MessageType.EnemyDamageMessage, "{0} deals {1} damage to you." },
            {MessageType.EnemyChangeDistanceMessage, "{0} moves and is now {1} meters away from you." },
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