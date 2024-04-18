using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Dice
{
    public static class DiceCalculator
    {

        public static DiceRollResult Calculate(int dice = 1, string? message = null, int flatDamage = 0, int sides = 6)
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
    }
}
