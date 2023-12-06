

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class Labels
    {
        public static Dictionary<LabelType, string> EnglishLabels = new Dictionary<LabelType, string>
        {
            {LabelType.ChangeWeaponButton, "Change" },
            {LabelType.EquipNewWeaponButton, "Add" }
        };
    }
}
