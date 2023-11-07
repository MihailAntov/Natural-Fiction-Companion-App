

using NFCombat2.Models.Programs;

namespace NFCombat2.Models.Player
{
    public class Hacker : Player
    {
        public static IList<Program> Programs { get; set; } = new List<Program>();

        public int Overload { get; set; }
        public int MaxOverload { get; set; }

    }
}
