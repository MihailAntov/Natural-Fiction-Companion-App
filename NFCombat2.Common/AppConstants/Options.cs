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

        public static Dictionary<(OptionType, CheckType), string> BulgarianOptions = new Dictionary<(OptionType, CheckType), string>()

        {
            {(OptionType.EndTurn, CheckType.None), "Край на хода" },
            {(OptionType.Move, CheckType.None), "Придвижи се" },
            {(OptionType.SkipTurn, CheckType.None), "Бягай" },
            {(OptionType.Attack, CheckType.None), "Атакувай отблизо" },
            {(OptionType.Shoot, CheckType.None), "Стреляй" },
            {(OptionType.Item, CheckType.None), "Използвай предмет" },
            {(OptionType.Program, CheckType.None), "Програма" },
            {(OptionType.DoNothing, CheckType.None), "Не прави нищо" },
            {(OptionType.Stay, CheckType.None), "Стой на място" },
            {(OptionType.Done, CheckType.None), "Край на стрелбата" },
            {(OptionType.StrengthCheckAttack,CheckType.Panel),"Счупи панела" },
            {(OptionType.StrengthCheckAttack,CheckType.River),"Бори се с течението на реката" },
            {(OptionType.StrengthCheckAttack,CheckType.Rocks),"Премести камъните" },
            {(OptionType.StrengthCheckAttack,CheckType.Door),"Разбий вратата" },
            {(OptionType.SwampAttack,CheckType.Swamp),"Бори се с блатната растителност" },
            {(OptionType.AdrenalineRush,CheckType.None),"Приток на адреналин (-{0})" },
            {(OptionType.Backflip,CheckType.None),"Задно салто" }
        };
    }
}
