

namespace NFCombat2.Common.Enums
{
    public enum MessageType
    {
        None,
        //combat effect messages
        BonusActionMessage,
        GuaranteedCritsMessage,
        DamageMessage,
        CritMessage,
        MissMessage,
        DamageAoeMessage,
        TakeDamageMessage,
        FreezeMessage,
        FreezeAoeMessage,
        IsFrozenMessage,
        HealMessage,
        ChangeDistanceMessage,
        Draw,
        //action messages
        ShootMessage,
        AoeShootMessage,
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
        EnemyPushedBackMessage,
        //enemy messages
        EnemyMoveMessage,
        EnemyShootMessage,
        EnemyAttackMessage,
        EnemyDefeatedMessage,
        EnemyDamageMessage,
        EnemyChangeDistanceMessage,
        EnemyCritMessage,
        EnemyMissMessage,

        //item messages
        UseMedkit,
        MaxOverloadIncrease,
        SteelPlateAbsorb,
        ProtectedFromMaser,
        NoEffect
        
        
    }
}
