namespace NFCombat2.Common.Helpers
{
    public static class DiceCalculator
    {
        public static DiceRollResult Calculate(int dice = 1, int flatDamage = 0, int sides = 6)
        {

            var result = new DiceRollResult() { FlatAmount = flatDamage };
            for (int i = 0; i < dice; i++)
            {
                var nextDice = new Dice(sides);
                nextDice.Roll();
                result.Dice.Add(nextDice);
            }
            return result;
        }

        //public static Dice RollSingle(int sides = 6)
        //{
        //    var dice = new Dice(sides, "dice1");
        //    dice.Roll();
        //    return dice;
        //}
    }
}
