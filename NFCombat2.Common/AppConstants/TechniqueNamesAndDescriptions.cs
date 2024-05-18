

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class TechniqueNamesAndDescriptions
    {
        public static Dictionary<TechniqueType, string> BulgarianTechniqueNames = new Dictionary<TechniqueType, string>()
        {
            {TechniqueType.Backflip, "Задно салто" },
            {TechniqueType.Sprint, "Спринт" },
            {TechniqueType.Anticipation, "Предварение" },
            {TechniqueType.Feint, "Финт" },
            {TechniqueType.Brace, "Прикладване" },
            {TechniqueType.DoubleGrip, "Двоен захват" },
            {TechniqueType.Resilience, "Устойчивост на болка" },
            {TechniqueType.FightningSpirit, "Борбен дух" },
            {TechniqueType.PrimalInstinct, "Първичен инстинкт" },
            {TechniqueType.Combo, "Серия" },
            {TechniqueType.BattleMastery, "Бойно майсторство" },
            {TechniqueType.IronWill, "Желязна воля" },
            {TechniqueType.Perfectionism, "Перфекционизъм" },
            {TechniqueType.DeadlyStrike, "Смъртоносен удар" },
        };

        public static Dictionary<TechniqueType, string> BulgarianTechniqueDescriptions = new Dictionary<TechniqueType, string>()
        {
            {TechniqueType.Backflip, "Веднъж на битка можеш да увеличиш дистанцията до противника с 2 метра." },
            {TechniqueType.Sprint, "По време на битка можеш да се придвижваш с до 6 метра на ход, вместо с обичайните 3." },
            {TechniqueType.Anticipation, "След ход, в който противникът се е придвижил, а ти – не, точността на оръжията ти се покачва с една степен (максимум S)." },
            {TechniqueType.Feint, "След ход, в който си се придвижил, противниците ти намаляват резултата от хвърлянето си за стрелба с 1." },
            {TechniqueType.Brace, "Ако в едната си ръка държиш стрелково оръжие, а в другата – не, можеш да стреляш по два пъти на ход." },
            {TechniqueType.DoubleGrip, "Ако в едната си ръка държиш оръжие за близък бой, а в другата – не, увеличи силата си с 2." },
            {TechniqueType.Resilience, "Намалявай всички щети от огнестрелни оръжия, които получиш, наполовина." },
            {TechniqueType.FightningSpirit, "Силата ти не намалява, ако точките ти за издръжливост са под максималното им ниво." },
            {TechniqueType.PrimalInstinct, "Когато довършиш противник от разстояние, можеш да си възстановиш до 2 зара издръжливост." },
            {TechniqueType.Combo, "След всеки спечелен рунд в близък бой нанасяй допълнителен зар щети на противника." },
            {TechniqueType.BattleMastery, "Можеш да използваш уменията си, без да плащаш издръжливост." },
            {TechniqueType.IronWill, "Точките ти за издръжливост могат да спаднат до -4, без да умреш. Ако победиш, издръжливостта ти става равна на 1." },
            {TechniqueType.Perfectionism, "Kогато трябва да нанесеш двойни щети на противник, удвои резултата още веднъж." },
            {TechniqueType.DeadlyStrike, "Ако спечелиш следващия рунд в близък бой, директно довършваш противника." },
        };

        public static Dictionary<TechniqueType, string> EnglishTechniqueNames = new Dictionary<TechniqueType, string>()

        {
            {TechniqueType.Backflip, "Backflip" },
            {TechniqueType.Sprint, "Sprint" },
            {TechniqueType.Anticipation, "Anticipation" },
            {TechniqueType.Feint, "Feint" },
            {TechniqueType.Brace, "Bracing" },
            {TechniqueType.DoubleGrip, "Double Grip" },
            {TechniqueType.Resilience, "Resilience" },
            {TechniqueType.FightningSpirit, "Fighting Spirit" },
            {TechniqueType.PrimalInstinct, "Primal Instinct" },
            {TechniqueType.Combo, "Combo Strike" },
            {TechniqueType.BattleMastery, "Battle Mastery" },
            {TechniqueType.IronWill, "Iron Will" },
            {TechniqueType.Perfectionism, "Perfectionism" },
            {TechniqueType.DeadlyStrike, "Deadly Strike" },
        };



        public static Dictionary<TechniqueType, string> EnglishTechniqueDescriptions = new Dictionary<TechniqueType, string>()

        {
            {TechniqueType.Backflip, "Once per combat you can increase the distance from your enemy by 2." },
            {TechniqueType.Sprint, "You can move by 6 meters per round instead of 3." },
            {TechniqueType.Anticipation, "If on the previous turn your enemy moved and you didn’t, your accuracy is increased by one (Max. S)" },
            {TechniqueType.Feint, "If you moved this turn, your enemies’ accuracy is reduced by one." },
            {TechniqueType.Brace, "If you’re holding a ranged weapon in one hand, and not in the other, you can shoot an additional time each turn." },
            {TechniqueType.DoubleGrip, "If you’re holding a melee weapon in one hand, and not in the other, increase your strength by 2." },
            {TechniqueType.Resilience, "Reduce all incoming ranged damage by half." },
            {TechniqueType.FightningSpirit, "Your strength does not drop if your health is below its maximum value." },
            {TechniqueType.PrimalInstinct, "When you finish an enemy from a distance, restore 2d health. "},
            {TechniqueType.Combo, "After you win a melee combat roll, deal an additional 1d damage to the opponent." },
            {TechniqueType.BattleMastery, "You can use your abilities without paying their health cost." },
            {TechniqueType.IronWill, "Your health can drop to -4 without you dying. If you win, your health becomes 1." },
            {TechniqueType.Perfectionism, "When you score a critical hit, double the damage an additional time." },
            {TechniqueType.DeadlyStrike, "If you win a round in melee combat, you instantly defeat the opponent." },
        };
    }
}
