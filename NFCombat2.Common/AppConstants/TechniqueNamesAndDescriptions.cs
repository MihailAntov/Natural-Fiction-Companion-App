

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
    }
}
