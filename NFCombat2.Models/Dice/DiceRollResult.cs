namespace NFCombat2.Models.Dice
{
    public class DiceRollResult
    {
        public int FlatAmount { get; set; }
        public ICollection<Dice> Dice { get; set; } = new List<Dice>();
    }
}
