

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ModeNames
    {
        public static Dictionary<ItemMode, string> EnglishModes = new Dictionary<ItemMode, string>()
        {
            {ItemMode.PoleMoveCloser, "Move closer" },
            {ItemMode.PoleMoveFuther, "Move further" }
        };

        public static Dictionary<ItemMode, string> BulgarianModes = new Dictionary<ItemMode, string>()

        {
            {ItemMode.PoleMoveCloser, "Приближаване" },
            {ItemMode.PoleMoveFuther, "Отдалечаване" }
        };
    }
}
