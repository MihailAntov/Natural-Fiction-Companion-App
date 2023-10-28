

namespace NFCombat2.Models.DiceRoller
{
    public static class DiceCalculator
    {
        public static int Calculate(int dice = 1, int flatDamage = 0, int sides = 6)
        {
            int result = flatDamage;
            Random random = new Random();
            for(int i = 0; i < dice; i++)
            {
                result += random.Next(1, sides + 1);
            }
            return result;
        }
    }
}
