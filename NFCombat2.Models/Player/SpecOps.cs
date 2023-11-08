

using NFCombat2.Models.SpecOps;

namespace NFCombat2.Models.Player
{
    public class SpecOps : Player
    {
        public IList<Technique> Techniques { get; set; } = new List<Technique>();

    }
}
