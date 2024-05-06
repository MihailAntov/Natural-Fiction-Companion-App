using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class Options
    {
        public static Dictionary<(OptionType, CheckType), string> EnglishOptions = new Dictionary<(OptionType, CheckType), string>()
        {
            {(OptionType.EndTurn, CheckType.None), "End your turn" },
            {(OptionType.Move, CheckType.None), "Move" },
            {(OptionType.SkipTurn, CheckType.None), "Run away" },
            {(OptionType.Attack, CheckType.None), "Melee attack" },
            {(OptionType.Shoot, CheckType.None), "Shoot" },
            {(OptionType.Item, CheckType.None), "Use an item" },
            {(OptionType.Program, CheckType.None), "Use a program" },
            {(OptionType.DoNothing, CheckType.None), "Do nothing" },
            {(OptionType.Stay, CheckType.None), "Stay where you are" },
            {(OptionType.Done, CheckType.None), "Done" },
            {(OptionType.StrengthCheckAttack,CheckType.Panel),"Try to break the panel" },
            {(OptionType.StrengthCheckAttack,CheckType.River),"Try to fight the river's current" },
            {(OptionType.StrengthCheckAttack,CheckType.Rocks),"Try to move the rocks" },
            {(OptionType.StrengthCheckAttack,CheckType.Door),"Try to break down the door" },
            {(OptionType.SwampAttack,CheckType.Swamp),"Try to fight the swamp plants" },
            {(OptionType.AdrenalineRush,CheckType.None),"Adrenaline Rush (-{0})" },
            {(OptionType.Backflip,CheckType.None),"Backflip" }
        };
    }
}
