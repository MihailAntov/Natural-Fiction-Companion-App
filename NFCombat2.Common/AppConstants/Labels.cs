

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class Labels
    {
        public static Dictionary<LabelType, string> EnglishLabels = new Dictionary<LabelType, string>
        {
            {LabelType.ChangeWeaponButton, "Change" },
            {LabelType.EquipNewWeaponButton, "Add" },
            {LabelType.UseItemButton, "Use" },
            {LabelType.AcceptCombatResult, "Accept" },
            {LabelType.RejectCombatResult, "Reject" },
            {LabelType.InvalidEpisodeNumber, "Invalid episode number" },
            {LabelType.CraftButton, "Craft" },
            {LabelType.ConfirmButton, "Confirm Episode" },
            {LabelType.Language, "Choose language" },
            {LabelType.SelectClass, "Choose a class" },
            {LabelType.PlayerName, "Name" },
            {LabelType.PlayerNameHint,"Enter your name here" },
            {LabelType.AddPlayerButton, "Create" }

        };

        public static Dictionary<LabelType, string> BulgarianLabels = new Dictionary<LabelType, string>
        {
            {LabelType.ChangeWeaponButton, "Смени" },
            {LabelType.EquipNewWeaponButton, "Добави" },
            {LabelType.UseItemButton, "Използвай" },
            {LabelType.AcceptCombatResult, "Приеми" },
            {LabelType.RejectCombatResult, "Откажи" },
            {LabelType.InvalidEpisodeNumber, "Невалиден номер на епизод" },
            {LabelType.CraftButton, "Създай" },
            {LabelType.ConfirmButton, "Потвърди номер на епизод" },
            {LabelType.Language, "Избери език" },
            {LabelType.SelectClass, "Избери клас" },
            {LabelType.PlayerName, "Име" },
            {LabelType.PlayerNameHint,"Въведи името на персонажа" },
            {LabelType.AddPlayerButton, "Създай" }
        };
    }
}
