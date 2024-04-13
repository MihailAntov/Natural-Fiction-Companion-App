

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class Messages
    {
        public static Dictionary<MessageType, string> EnglishMessages = new Dictionary<MessageType, string>()
        {
            //effects
            {MessageType.BonusActionMessage, "You can take another action this turn." },
            {MessageType.GuaranteedCritsMessage, "Your next {0} shots deal double damage!" },
            {MessageType.DamageMessage, "{0} takes {1} damage." },
            {MessageType.CritMessage, "You deal double damage! {0} takes {1} damage." },
            {MessageType.MissMessage, "You miss!" },
            {MessageType.DamageAoeMessage, "{0} enemies each take {1} damage." },
            {MessageType.TakeDamageMessage, "You take {0} damage." },
            {MessageType.FreezeAoeMessage, "{0} enemies cannot move for {1} turns." },
            {MessageType.FreezeMessage, "{0} cannot move for {1} turns." },
            {MessageType.IsFrozenMessage, "{0} cannot move. ({1} turns remaining)" },
            {MessageType.HealMessage, "You restore {0} health." },
            {MessageType.ChangeDistanceMessage, "{0} is now at {1} meters." },
            {MessageType.Draw, "No one takes the upper hand." },
            {MessageType.PathogenDecrease, "Your pathogen level decreases by {0} and is now {1}." },
            {MessageType.PathogenIncrease, "Your pathogen level increases by {0} and is now {1}." },
            {MessageType.TraumaDecrease, "Your trauma level decreases by {0} and is now {1}." },
            {MessageType.TraumaIncrease, "Your trauma level increases by {0} and is now {1}." },
            {MessageType.IonizationDecrease, "Your ionization level decreases by {0} and is now {1}." },
            {MessageType.IonizationIncrease, "Your ionization level increases by {0} and is now {1}." },
            {MessageType.OverloadIncrease, "Your overload level increases by {0} and is now {1}." },
            {MessageType.TemporaryStrengthDamage, "You fail the roll and lose {0} strength for the rest of the fight." },
            {MessageType.SkillCheckSuccess, "It's workng! Keep at it!" },
            {MessageType.HoldBreath, "You manage to hold your breath." },
            {MessageType.NoDamage, "You successfully defend yourself but deal no damage." },
            //actions
            {MessageType.ShootMessage, "You shoot {0} with your {1}." },
            {MessageType.AoeShootMessage, "You shoot {0} enemies with your {1}." },
            {MessageType.AttackMessage, "You attack {0} in close combat." },
            {MessageType.SkillCheckDoor, "You attack {0} in close combat." },
            {MessageType.SkillCheckRocks, "You try to move the rocks." },
            {MessageType.SkillCheckRiver, "You fight against the river's current." },
            {MessageType.SkillCheckPanel, "You try to break the panel." },
            {MessageType.SkillCheckSwamp, "You fight against the swamp plants." },
            {MessageType.UseProgramMessage, "You use {0}. Your overload gauge is now at {1}." },
            {MessageType.UseItemWithQuantityMessage, "You use one of your {0}. You have {0} left." },
            {MessageType.UseItemMessage, "You use your {0}." },
            {MessageType.UseTechniqueMessage, "You use {}." },
            {MessageType.MoveCloserMessage, "You move in closer." },
            {MessageType.MovePassMessage, "You stay where you are." },
            {MessageType.ActionPassMessage, "You wait." },
            {MessageType.EnemyPushedBackMessage, "{0} is pushed back by your shield's force field." },
            //program action messages
            {MessageType.ProgramHealMessage, "Your program heals you." },
            {MessageType.ProgramBonusActionmessage, "Your program increases your reflexes." },
            {MessageType.ProgramDamageMessage, "Your program damages your enemy." },
            {MessageType.ProgramCritMessage, "Your program focuses your aim." },
            {MessageType.ProgramFreezeMessage, "Your program disrupts the movement of your enemy." },
            {MessageType.ProgramDisableTentacleMessage, "Your program disables the tentacle." },
            {MessageType.ProgramNoEffect,"Your program has no effect." },
            //enemy messages
            {MessageType.EnemyMoveMessage, "{0} moves in closer." }, 
            {MessageType.EnemyMovePassMessage, "{0} is unable to move." }, 
            {MessageType.EnemyMoveAwayMessage, "{0} tries to run away." }, 
            {MessageType.EnemyShootMessage, "{0} shoots at you." },
            {MessageType.EnemyAttackMessage, "{0} attacks you in close combat." },
            {MessageType.EnemyDamageMessage, "{0} deals {1} damage to you." },
            {MessageType.EnemyChangeDistanceMessage, "{0} is now {1} meters away from you." },
            {MessageType.EnemyDefeatedMessage, "{0} is defeated!" },
            {MessageType.EnemyMissMessage, "{0} misses!" },
            {MessageType.EnemyCritMessage, "{0} deals double damage! You lose {1} life." },
            {MessageType.SwampAttack, "The swamp is emitting poisonous fumes." },
            {MessageType.SpawnTentacle, "A new {0} appears." },
            {MessageType.TraumaTentacleAttack, "Your metal hand attacks you." },
            {MessageType.TraumaTentacleMiss, "You fight it off." },
            {MessageType.IonizationTentacleAttack, "The maser fires at you." },
            {MessageType.IonizationTentacleMiss, "It misses." },
            {MessageType.PathogenTentacleAttack, "The vents emit pale green gas." },
            {MessageType.PathogenTentacleMiss, "You manage to hold your breath." },

            //item messages
            {MessageType.SteelPlateAbsorb, "Your steel plate absorbed {0} damage and has {1} durability left." },
            {MessageType.ProtectedFromMaser, "The arc from your whip melts the maser's board." },
            {MessageType.NoEffect, "Your {0} had no effect." },
            {MessageType.PoleMoveCloser, "Your distance to {0} is reduced." },
            {MessageType.PoleMoveFurther, "Your distance to {0} is increased." },
            {MessageType.FuelIncrease, "Your fuel increases by {0}% and is now {0}%." },
            {MessageType.EquippedToWeapon, "Successfully equipped {0} to {1}." },
            {MessageType.UnequippedFromWeapon, "Successfully unequipped {0}." },
            {MessageType.MaxOverloadIncrease, "Your maximum overload increases by {0} and is now {1}." },
            {MessageType.StrengthIncrease, "Your strength is increased by {0} for the remainder of the fight." },
            {MessageType.WrenchThrow, "You throw a wrench at {0}." },
            {MessageType.GasMaskProteced, "Your gas mask is protecting you." },

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