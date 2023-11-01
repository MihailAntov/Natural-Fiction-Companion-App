

namespace NFCombat2.Common.Enums
{
    public enum MessageType
    {
        //combat effect messages
        BonusActionMessage,
        CritMessage,
        DamageMessage,
        DamageAoeMessage,
        TakeDamageMessage,
        FreezeMessage,
        FreezeAoeMessage,
        IsFrozenMessage,
        HealMessage,
        ChangeDistanceMessage,
        //action messages
        ShootMessage,
        AttackMessage,
        UseProgramMessage,
        ProgramHealMessage,
        ProgramFreezeMessage,
        ProgramDamageMessage,
        ProgramBonusActionmessage,
        ProgramCritMessage,
        UseItemMessage,
        UseItemWithQuantityMessage,
        UseTechniqueMessage,
        MoveCloserMessage,
        MovePassMessage,
        ActionPassMessage,
        //enemy messages
        EnemyMoveMessage,
        EnemyShootMessage,
        EnemyAttackMessage,
        EnemyDefeatedMessage
    }
}
