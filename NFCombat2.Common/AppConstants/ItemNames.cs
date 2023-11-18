

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ItemNames
    {
        private static Dictionary<ItemType, string> BulgarianNames = new Dictionary<ItemType, string>()
        {

        };

        private static Dictionary<ItemType, string> EnglishNames = new Dictionary<ItemType, string>()
        {

        };

        public static string GetItemName(ItemType type, Language language)
        {
            switch(language)
            {
                case Language.Bulgarian:
                    return BulgarianNames[type];
                case Language.English:
                default:
                    return EnglishNames[type];
                    
            }
        }
    }
}
