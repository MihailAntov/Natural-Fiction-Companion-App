

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class EnemyNames
    {
        public static Dictionary<EnemyType, string> EnglishEnemies = new Dictionary<EnemyType, string>()
        {
            {EnemyType.TraumaTentacle, "Cable Tentacle (Metal Hand)" },
            {EnemyType.IonizationTentacle, "Cable Tentacle (Vents)" },
            {EnemyType.PathogenTentacle, "Cable Tentacle (Amonia Maser)" },
        };
    }
}
