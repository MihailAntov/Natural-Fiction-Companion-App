

namespace NFCombat2.Models.Player
{
    public class SpecOps : Player
    {
        public static IList<Skill> SpecialMoves { get; set; } = new List<Skill>();

    }
}
